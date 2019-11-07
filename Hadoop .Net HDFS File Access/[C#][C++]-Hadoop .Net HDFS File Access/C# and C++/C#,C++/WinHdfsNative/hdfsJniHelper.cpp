/**
* Copyright 2006 The Apache Software Foundation
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/


using namespace std;
#include <hash_map>
#include <stdlib.h>
#include <string.h> 
#include <error.h>
#include "hdfsJniHelper.h"

//static pthread_mutex_t hdfsHashMutex = PTHREAD_MUTEX_INITIALIZER;
//static pthread_mutex_t jvmMutex = PTHREAD_MUTEX_INITIALIZER;
static volatile int hashTableInited = 0;

#define LOCK_HASH_TABLE() //pthread_mutex_lock(&hdfsHashMutex)
#define UNLOCK_HASH_TABLE() //pthread_mutex_unlock(&hdfsHashMutex)
#define LOCK_JVM_MUTEX() //pthread_mutex_lock(&jvmMutex)
#define UNLOCK_JVM_MUTEX() //pthread_mutex_unlock(&jvmMutex)


/** The Native return types that methods could return */
#define VOID          'V'
#define JOBJECT       'L'
#define JARRAYOBJECT  '['
#define JBOOLEAN      'Z'
#define JBYTE         'B'
#define JCHAR         'C'
#define JSHORT        'S'
#define JINT          'I'
#define JLONG         'J'
#define JFLOAT        'F'
#define JDOUBLE       'D'


/**
* MAX_HASH_TABLE_ELEM: The maximum no. of entries in the hashtable.
* It's set to 4096 to account for (classNames + No. of threads)
*/
#define MAX_HASH_TABLE_ELEM 4096

struct eqstr
{
    bool operator()(const char* s1, const char* s2) const
    {
        return strcmp(s1, s2) == 0;
    }
};

static hash_map<const char*, void*> hash_table;


static int validateMethodType(MethType methType)
{
    if (methType != STATIC && methType != INSTANCE) {
        fprintf(stderr, "Unimplemented method type\n");
        return 0;
    }
    return 1;
}


static int hashTableInit(void)
{

    if (!hashTableInited) {
        LOCK_HASH_TABLE();
        if (!hashTableInited) {
            hashTableInited = 1;
        }
        UNLOCK_HASH_TABLE();
    }
    return 1;
}


static int insertEntryIntoTable(const char *key, void *data)
{
    if (key == NULL || data == NULL) {
        return 0;
    }
    if (! hashTableInit()) {
        return -1;
    }
    LOCK_HASH_TABLE();
    hash_table[key] = data;
    UNLOCK_HASH_TABLE();
    if (data == NULL) {
        fprintf(stderr, "warn adding key (%s) to hash table, <%d>: %s\n",
            key, errno, strerror(errno));
    }  
    return 0;
}



static void* searchEntryFromTable(const char *key)
{
    void* data;
    if (key == NULL) {
        return NULL;
    }
    hashTableInit();
    LOCK_HASH_TABLE();
    data = hash_table[key];
    UNLOCK_HASH_TABLE();
    if (data != NULL) {
        return data;
    }
    return NULL;
}



int invokeMethod(JNIEnv *env, RetVal *retval, Exc *exc, MethType methType,
    jobject instObj, const char *className,
    const char *methName, const char *methSignature, ...)
{
    va_list args;
    jclass cls;
    jmethodID mid;
    jthrowable jthr;
    const char *str; 
    char returnType;

    if (! validateMethodType(methType)) {
        return -1;
    }
    cls = globalClassReference(className, env);
    if (cls == NULL) {
        return -2;
    }

    mid = methodIdFromClass(className, methName, methSignature, 
        methType, env);
    if (mid == NULL) {
        (*env).ExceptionDescribe();
        return -3;
    }

    str = methSignature;
    while (*str != ')') str++;
    str++;
    returnType = *str;
    va_start(args, methSignature);
    if (returnType == JOBJECT || returnType == JARRAYOBJECT) {
        jobject jobj = NULL;
        if (methType == STATIC) {
            jobj = (*env).CallStaticObjectMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            jobj = (*env).CallObjectMethodV(instObj, mid, args);
        }
        retval->l = jobj;
    }
    else if (returnType == VOID) {
        if (methType == STATIC) {
            (*env).CallStaticVoidMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            (*env).CallVoidMethodV(instObj, mid, args);
        }
    }
    else if (returnType == JBOOLEAN) {
        jboolean jbool = 0;
        if (methType == STATIC) {
            jbool = env->CallStaticBooleanMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            jbool = env->CallBooleanMethodV(instObj, mid, args);
        }
        retval->z = jbool;
    }
    else if (returnType == JSHORT) {
        jshort js = 0;
        if (methType == STATIC) {
            js = (*env).CallStaticShortMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            js = (*env).CallShortMethodV(instObj, mid, args);
        }
        retval->s = js;
    }
    else if (returnType == JLONG) {
        jlong jl = -1;
        if (methType == STATIC) {
            jl = env->CallStaticLongMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            jl = env->CallLongMethodV(instObj, mid, args);
        }
        retval->j = jl;
    }
    else if (returnType == JINT) {
        jint ji = -1;
        if (methType == STATIC) {
            ji = env->CallStaticIntMethodV(cls, mid, args);
        }
        else if (methType == INSTANCE) {
            ji = env->CallIntMethodV(instObj, mid, args);
        }
        retval->i = ji;
    }
    va_end(args);

    jthr = env->ExceptionOccurred();
    if (jthr != NULL) {
        if (exc != NULL)
            *exc = jthr;
        else
            env->ExceptionDescribe();
        return -1;
    }
    return 0;
}

jarray constructNewArrayString(JNIEnv *env, Exc *exc, const char **elements, int size) {
    const char *className = "Ljava/lang/String;";
    jobjectArray result;
    int i;
    jclass arrCls = env->FindClass(className);
    if (arrCls == NULL) {
        fprintf(stderr, "could not find class %s\n",className);
        return NULL; /* exception thrown */
    }
    result = env->NewObjectArray(size, arrCls,
        NULL);
    if (result == NULL) {
        fprintf(stderr, "ERROR: could not construct new array\n");
        return NULL; /* out of memory error thrown */
    }
    for (i = 0; i < size; i++) {
        jstring jelem = env->NewStringUTF(elements[i]);
        if (jelem == NULL) {
            fprintf(stderr, "ERROR: jelem == NULL\n");
        }
        env->SetObjectArrayElement(result, i, jelem);
        env->DeleteLocalRef(jelem);
    }
    return result;
}

jobject constructNewObjectOfClass(JNIEnv *env, Exc *exc, const char *className, 
    const char *ctorSignature, ...)
{
    va_list args;
    jclass cls;
    jmethodID mid; 
    jobject jobj;
    jthrowable jthr;

    cls = globalClassReference(className, env);
    if (cls == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }

    mid = methodIdFromClass(className, "<init>", ctorSignature, 
        INSTANCE, env);
    if (mid == NULL) {
        env->ExceptionDescribe();
        return NULL;
    } 
    va_start(args, ctorSignature);
    jobj = env->NewObjectV(cls, mid, args);
    va_end(args);
    jthr = env->ExceptionOccurred();
    if (jthr != NULL) {
        if (exc != NULL)
            *exc = jthr;
        else
            env->ExceptionDescribe();
    }
    return jobj;
}




jmethodID methodIdFromClass(const char *className, const char *methName, 
    const char *methSignature, MethType methType, 
    JNIEnv *env)
{
    jclass cls = globalClassReference(className, env);
    if (cls == NULL) {
        fprintf(stderr, "could not find class %s\n", className);
        return NULL;
    }

    jmethodID mid = 0;
    if (!validateMethodType(methType)) {
        fprintf(stderr, "invalid method type\n");
        return NULL;
    }

    if (methType == STATIC) {
        mid = env->GetStaticMethodID(cls, methName, methSignature);
    }
    else if (methType == INSTANCE) {
        mid = env->GetMethodID(cls, methName, methSignature);
    }
    if (mid == NULL) {
        fprintf(stderr, "could not find method %s from class %s with signature %s\n",methName, className, methSignature);
    }
    return mid;
}


jclass globalClassReference(const char *className, JNIEnv *env)
{
    jclass clsLocalRef;
    jclass cls = (jclass)searchEntryFromTable(className);
    if (cls) {
        return cls; 
    }

    clsLocalRef = env->FindClass(className);
    if (clsLocalRef == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }
    cls = (jclass)env->NewGlobalRef(clsLocalRef);
    if (cls == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }
    env->DeleteLocalRef(clsLocalRef);
    insertEntryIntoTable(className, cls);
    return cls;
}


char *classNameOfObject(jobject jobj, JNIEnv *env) {
    jclass cls, clsClass;
    jmethodID mid;
    jstring str;
    const char *cstr;
    char *newstr;

    cls = (jclass)env->GetObjectClass(jobj);
    if (cls == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }
    clsClass = env->FindClass("java/lang/Class");
    if (clsClass == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }
    mid = env->GetMethodID(clsClass, "getName", "()Ljava/lang/String;");
    if (mid == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }
    str = (jstring)env->CallObjectMethod(cls, mid);
    if (str == NULL) {
        env->ExceptionDescribe();
        return NULL;
    }

    cstr = env->GetStringUTFChars(str, NULL);
    newstr = strdup(cstr);
    env->ReleaseStringUTFChars(str, cstr);
    if (newstr == NULL) {
        perror("classNameOfObject: strdup");
        return NULL;
    }
    return newstr;
}




/**
* getJNIEnv: A helper function to get the JNIEnv* for the given thread.
* If no JVM exists, then one will be created. JVM command line arguments
* are obtained from the LIBHDFS_OPTS environment variable.
*
* @param: None.
* @return The JNIEnv* corresponding to the thread.
*/
JNIEnv* getJNIEnv(void)
{

    const jsize vmBufLength = 1;
    JavaVM* vmBuf[vmBufLength]; 
    JNIEnv *env;
    jint rv = 0; 
    jint noVMs = 0;

    // Only the first thread should create the JVM. The other trheads should
    // just use the JVM created by the first thread.
    LOCK_JVM_MUTEX();

    rv = JNI_GetCreatedJavaVMs(&(vmBuf[0]), vmBufLength, &noVMs);
    if (rv != 0) {
        fprintf(stderr, "JNI_GetCreatedJavaVMs failed with error: %d\n", rv);
        UNLOCK_JVM_MUTEX();
        return NULL;
    }

    if (noVMs == 0) {
        //Get the environment variables for initializing the JVM
        char *hadoopClassPath = getenv("CLASSPATH");
        if (hadoopClassPath == NULL) {
            fprintf(stderr, "Environment variable CLASSPATH not set!\n");
            UNLOCK_JVM_MUTEX();
            return NULL;
        } 
        char *hadoopClassPathVMArg = "-Djava.class.path=";
        size_t optHadoopClassPathLen = strlen(hadoopClassPath) + 
            strlen(hadoopClassPathVMArg) + 1;
        char *optHadoopClassPath = (char*)malloc(sizeof(char)*optHadoopClassPathLen);
        _snprintf(optHadoopClassPath, optHadoopClassPathLen,
            "%s%s", hadoopClassPathVMArg, hadoopClassPath);

        int noArgs = 1;
        //determine how many arguments were passed as LIBHDFS_OPTS env var
        char *hadoopJvmArgs = getenv("LIBHDFS_OPTS");
        char jvmArgDelims[] = " ";
        if (hadoopJvmArgs != NULL)  {
            char *result = NULL;
            result = strtok( hadoopJvmArgs, jvmArgDelims );
            while ( result != NULL ) {
                noArgs++;
                result = strtok( NULL, jvmArgDelims);
            }
        }
        JavaVMOption *options = (JavaVMOption *)malloc(noArgs * sizeof(JavaVMOption));
        options[0].optionString = optHadoopClassPath;
        //fill in any specified arguments
        if (hadoopJvmArgs != NULL)  {
            char *result = NULL;
            result = strtok( hadoopJvmArgs, jvmArgDelims );	
            int argNum = 1;
            for (;argNum < noArgs ; argNum++) {
                options[argNum].optionString = result; //optHadoopArg;
            }
        }

        //Create the VM
        JavaVMInitArgs vm_args;
        JavaVM *vm;
        vm_args.version = JNI_VERSION_1_2;
        vm_args.options = options;
        vm_args.nOptions = noArgs; 
        vm_args.ignoreUnrecognized = 1;

        rv = JNI_CreateJavaVM(&vm, (void**)&env, &vm_args);
        if (rv != 0) {
            fprintf(stderr, "Call to JNI_CreateJavaVM failed "
                "with error: %d\n", rv);
            UNLOCK_JVM_MUTEX();
            return NULL;
        }

        free(optHadoopClassPath);
        free(options);
    }
    else {
        //Attach this thread to the VM
        JavaVM* vm = vmBuf[0];
        rv = vm->AttachCurrentThread((void**)&env, 0);
        if (rv != 0) {
            fprintf(stderr, "Call to AttachCurrentThread "
                "failed with error: %d\n", rv);
            UNLOCK_JVM_MUTEX();
            return NULL;
        }
    }
    UNLOCK_JVM_MUTEX();

    return env;
}
