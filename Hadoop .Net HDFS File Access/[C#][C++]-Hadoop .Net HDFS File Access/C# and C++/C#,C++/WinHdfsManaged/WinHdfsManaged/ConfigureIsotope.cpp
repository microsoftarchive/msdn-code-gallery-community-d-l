#include "stdafx.h"
#include "ConfigureIsotope.h"
#include <msclr/marshal.h>
#include <msclr/marshal_cppstd.h>
#include <string>

namespace
{
    // Gets an environment variable from the CRT
    // This is a copy of the process' "environment" obtained using GetEnvironmentStrings
    // and is cached as soon as the CRT is loaded.    
    System::String^ GetCRTEnvironmentVariable(System::String^ envVariable)
    {
        auto envVariableString = msclr::interop::marshal_as<std::wstring> (envVariable);

        size_t requiredLength;
        _wgetenv_s(&requiredLength, nullptr, 0, envVariableString.c_str());

        if (requiredLength == 0)
        {
            return System::String::Empty;
        }
        
        std::vector<wchar_t> envValuePtr(requiredLength);
        _wgetenv_s(&requiredLength, envValuePtr.data(), requiredLength, envVariableString.c_str());
        return msclr::interop::marshal_as<System::String^> (envValuePtr.data());
    }

    void SetCRTEnvironemtVariable(System::String^ envVariable, System::String^ value)
    {
        auto envVariableString = msclr::interop::marshal_as<std::wstring> (envVariable);
        auto valueString       = msclr::interop::marshal_as<std::wstring> (value);
        _wputenv_s(envVariableString.c_str(), valueString.c_str());
    }

    // Adds a directory to the DLL search path
    void AddDllPath(System::String^ path)
    {
        if (!System::IO::Directory::Exists(path))
        {
            throw gcnew System::IO::FileNotFoundException(path + " was not found.");
        }
        ::SetDllDirectoryW(msclr::interop::marshal_as<std::wstring>(path).c_str());
    }
}

namespace Microsoft
{
    namespace Hdfs
    { 

        void ConfigureIsotope::Setup()
        {
            if (!_isSetup)
            {
                FindIsotope();
                FindJava();
                FindJars();
                SetupPath();
                SetupJavaHome();
                SetupClassPath();
                _isSetup = true;
            }
        }

        void ConfigureIsotope::FindIsotope()
        {
            _hadoopHome = System::Environment::GetEnvironmentVariable("HADOOP_HOME");
            if (_hadoopHome == nullptr)
            {
                throw gcnew System::IO::FileNotFoundException("HADOOP_HOME is not defined, please ensure Isotope is installed correctly.");
            }

            _isotopeHome = System::IO::Path::GetDirectoryName(_hadoopHome);
        }

        void ConfigureIsotope::FindJava()
        {
            _javaRuntime = FindJre(System::IO::Path::Combine(_isotopeHome, "java"));
            _javaHome = System::IO::Path::GetDirectoryName(_javaRuntime);
        }

        void ConfigureIsotope::FindJars()
        {
            System::String^ hadoopLibs = System::IO::Path::Combine(_hadoopHome, "lib");

            System::String^ hadoopCore              = FindFile(_hadoopHome, "hadoop-core-*.jar", "Base Hadoop.");
            System::String^ commonsLoggingJar       = FindFile(hadoopLibs, "commons-logging-1.*.jar", "Apache Commons Logging.");
            System::String^ commonsConfigurationJar = FindFile(hadoopLibs, "commons-configuration-1.*.jar", "Apache Commons Configuration.");
            System::String^ commonsLangJar          = FindFile(hadoopLibs, "commons-lang-2*.jar", "Apache Commons Language.");

            _jarFiles = gcnew System::Collections::Generic::List<System::String^>();
            _jarFiles->Add(hadoopCore);
            _jarFiles->Add(commonsLoggingJar);
            _jarFiles->Add(commonsConfigurationJar);
            _jarFiles->Add(commonsLangJar);
        }

        System::String^ ConfigureIsotope::FindJre(System::String^ dir)
        {        
            auto dirs = System::Linq::Enumerable::LastOrDefault(System::IO::Directory::EnumerateDirectories(dir, "jre", System::IO::SearchOption::AllDirectories));

            if (dirs == nullptr)
            {
                throw gcnew System::IO::FileNotFoundException("JRE could not be found, please ensure Isotope is installed correctly.");
            }
            return dirs;
        }

        System::String^ ConfigureIsotope::FindFile(System::String^ path, System::String^ pattern)
        {
            return FindFile(path, pattern, pattern);
        }

        System::String^ ConfigureIsotope::FindFile(System::String^ path, System::String^ pattern, System::String^ description)
        {        
            auto file = System::Linq::Enumerable::LastOrDefault(System::IO::Directory::EnumerateFiles(path, pattern));
            if (file == nullptr)
            {
                throw gcnew System::IO::FileNotFoundException(description);
            }
            return file;
        }

        void ConfigureIsotope::SetupClassPath()
        {        
            for each (System::String^ jar in _jarFiles)
            {
                SetEnvironmentVariable("CLASSPATH", jar, EnvironmentVariableMode::APPEND, false);
            }
        }

        void ConfigureIsotope::SetupJavaHome()
        {
            SetEnvironmentVariable("JAVA_HOME", _javaHome, EnvironmentVariableMode::OVERWRITE, false);
        }

        void ConfigureIsotope::SetupPath()
        {
            AddDllPath(System::IO::Path::Combine(_javaRuntime,"bin"));
            AddDllPath(System::IO::Path::Combine(_javaRuntime,"bin", "server"));
        }

        System::String^ ConfigureIsotope::Quotify(System::String^ value)
        {
            return (value->StartsWith("\"") && value->EndsWith("\"")) ? value : ("\""+value+"\"");        
        }

        void ConfigureIsotope::SetEnvironmentVariable(System::String^ env, System::String^ newValue, EnvironmentVariableMode mode, bool quotify)
        {        
            if (quotify)
            {
                newValue = Quotify(newValue);
            }
        
            auto value = GetCRTEnvironmentVariable(env);

            if (value == System::String::Empty || mode == EnvironmentVariableMode::OVERWRITE)
            {
                value = newValue;
            }
            else if (mode == EnvironmentVariableMode::PREPEND)
            {
                value = newValue + ";" + value;
            }
            else
            {
                value = value + ";" + newValue;
            }

            SetCRTEnvironemtVariable(env, value);        
        }

        void ConfigureIsotope::SetEnvironmentVariable(System::String^ env, System::String^ newValue)
        {
            SetEnvironmentVariable(env, newValue, EnvironmentVariableMode::APPEND, true);
        }
    }
}
