Purpose
=======
This sample demonstrates how to use the Flat file connection manager and Flat file
Source/Destination adapter to transfer data between two files. 
The project contains one package and one txt file.
The package contains a dataflow composed of one flat file source and one flat file destination.
The flat file source uses a flat file connection manager that pulls data from the text file, 
and is configured to use | as column delimiter.
The flat file destination uses a flat file connection manager that is configured to use Tab as
column delimiter, and specify that the first row is column names.

===========
Configuration
===========
You will need to change the file path of the flat file src connection manager to the path of the
Address.txt contained in this project on your computer, and configure the path of the Flat file
dest connection manager to where you want to put the desintation file.