#pragma once

namespace Microsoft
{
    namespace Hdfs
    { 
        /// <summary>
        ///   A utility class for setting up environment variables needed
        ///   for LIBHDFS
        /// </summary>
        public ref class ConfigureIsotope sealed abstract
        {
        public:
            static void Setup();

        private:
            static System::String ^_hadoopHome;
            static System::String ^_isotopeHome;
            static System::Collections::Generic::List<System::String^> ^_jarFiles;
            static System::String ^_javaHome;
            static System::String ^_javaRuntime;
            static bool _isSetup = false;

            enum class EnvironmentVariableMode
            {
                APPEND,
                PREPEND,
                OVERWRITE
            };

        private:
            /// <summary>
            ///   Set the CLASSPATH environment variable
            /// </summary>
            static void SetupClassPath();

            /// <summary>
            ///   Set the JAVA_HOME environment variable
            /// </summary>
            static void SetupJavaHome();

            /// <summary>
            ///   Set the PATH environment variable
            /// </summary>
            static void SetupPath();

            /// <summary>
            ///   Use the HADOOP_HOME environment variable set by the Isotope installer
            ///   to probe for Isotope and Java
            /// </summary>
            static void FindIsotope();

            /// <summary>
            ///   Find the JRE that is bundled with Isotope
            /// </summary>
            static void FindJava();

            /// <summary>
            ///   Find the dependent JAR files required for LIBHDFS
            ///   to work
            /// </summary>
            static void FindJars();

            /// <summary>
            ///   Find the JRE subdirectory given a root directory
            /// </summary>
            /// <param name="dir">
            ///   The root directory
            /// </param>
            /// <returns>
            ///   The full patch of the JRE directory
            /// </returns>
            static System::String^ FindJre(System::String^ dir);

            /// <summary>
            ///   Find a file in a directory matching a particular pattern.
            ///   If there are multiple files, returns the last file
            /// </summary>
            /// <param name="path">
            ///   The path to be searched
            /// </param>
            /// <param name="pattern">
            ///   The pattern to be matched
            /// </param>
            /// <returns>
            ///   The file matching the given pattern
            /// </returns>
            static System::String^ FindFile(System::String^ path, System::String^ pattern);

            static System::String^ FindFile(System::String^ path, System::String^ pattern, System::String^ description);

            static System::String^ Quotify(System::String^ value);

            /// <summary>
            ///   Sets an environment variable.
            /// </summary>
            /// <param name="env">
            ///   The environment variable to be set
            /// </param>
            /// <param name="newValue">
            ///   The new value of the environment variable, <paramref name="env"/>
            /// </param>
            /// <param name="mode">
            ///   The mode in which to set <paramref name="newValue"/>: append, prepend or overwrite
            /// </param>
            static void SetEnvironmentVariable(System::String^ env, System::String^ newValue, EnvironmentVariableMode mode, bool quotify);

            static void SetEnvironmentVariable(System::String^ env, System::String^ newValue);
        };
    }
}