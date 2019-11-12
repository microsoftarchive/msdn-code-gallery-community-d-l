# DirectCompute Basic Win32 Samples
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
- DirectX SDK
- DirectCompute
## Topics
- Graphics and 3D
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>This is the DirectX SDK's Direct3D 11 BasicCompute11 and ComputeShaderSort11 samples updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. These are samples Win32 desktop console DirectX 11.0 applications
 for Windows 8, Windows 7, and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.&nbsp;</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop console samples running on Windows Vista, Windows 7, and Windows 8. This is not intended for use with Windows Store apps or Windows RT, although the basic techniques are applicable.</strong></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>These are Win32 desktop console applications which demonstrate use of DirectCompute (aka Direct3D 11 Compute Shaders). For more complicated examples that combine DirectCompute with 3D rendering, see
<a href="http://code.msdn.microsoft.com/DirectCompute-Graphics-425de5a8">DirectCompute Graphics Win32 Samples</a>.</p>
<h2>BasicCompute11</h2>
<p>This sample shows the basic usage of DirectX11 Compute Shader (aka DirectCompute) by implementing array A &#43; array B.</p>
<p><img id="94433" src="94433-basiccompute11.jpg" alt="" width="90" height="45"></p>
<h3>How the Sample Works</h3>
<p>Setting up the Compute Shader involves the following steps:</p>
<ol>
<li>Create a D3D11 device and context. Make sure to check the feature level of the device created. Based on what graphics card is installed in the system, possibilities are:
<ol>
<li>If an FL11 device has been created, we get full Compute Shader 5.0 capability.
</li><li>However, if we have an FL10 or FL10.1 device, Compute Shader 4.0/4.1 is potentially available, since CS4.0/4.1 is available on most DirectX 10 cards but not all of them. Call CheckFeatureSupport to see whether CS4.0/4.1 is available. Refer to the sample
 code to see how this is done. </li><li>If we get an FL9.x device, Compute Shader is not available. </li></ol>
</li><li>Compile and then create the Compute Shader. </li><li>Create input resource for the Compute Shader and fill them with data. As we are doing array A &#43; array B, we create two buffers as the input resource.
</li><li>Create an SRV (shader resource view) for both of the input buffer resources. Shader resource view is used to bind input resources to shaders.
</li><li>Create output resource for the Compute Shader. </li><li>Create a UAV (unordered resource view) for the output resource. Unordered resource view is used to bind output resources to Compute Shaders. CS4.0/4.1 can have only one output resource bound to a Compute Shader at a time. CS5.0 doesn't have this limitation.
</li><li>Execute the Compute Shader by calling Dispatch. </li></ol>
<h3>Build Options</h3>
<p>The sample and the HLSL code supports two additional build modes controlled by compile-time defines.</p>
<ul>
<li><code>USE_STRUCTURED_BUFFERS</code>: If this is defined, then the sample and shader uses structured buffer types. If this is commented out, then the sample and shader use raw buffer types.
</li><li><code>TEST_DOUBLE</code>: If this is defined, then the sample tests a double-precision data type. Note that double support requires Compute Shader 5.0 and optional driver support for double-precision shaders. If the sample and shader are compiled with TEST_DOUBLE
 defined, then the sample will only run on 11-class hardware with doubles support, or it will fall back to using the Reference device.
</li></ul>
<p>&nbsp;</p>
<h2>ComputeShaderSort11</h2>
<p>This sample demonstrates the basic usage of the DirectX 11 Compute Shader 4.0 feature to implement a bitonic sort algorithm. It also highlights the considerations that must be taken to achieve good performance.</p>
<p><img id="94435" src="94435-computeshadersort11.jpg" alt="" width="90" height="45"></p>
<h4>Bitonic Sort</h4>
<p><a href="http://en.wikipedia.org/wiki/Bitonic_sorter">Bitonic sort</a> is a simple algorithm that works by sorting the data set into alternating ascending and descending sorted sequences. These sequences can then be combined and sorted to produce larger
 sequences. This is repeated until you produce one final ascending sequence for the sorted data.</p>
<h4>Bitonic Sort with Compute Shader</h4>
<p>Now let's look at how to implement the bitonic sort in computer shader for a single thread group. To achieve good performance when implementing the sorting algorithm, it is important to limit the amount of memory accesses where possible. Because this algorithm
 has very few ALU operations and is limited by its memory accesses, we perform portions of the sort in shared memory, which is significantly faster. Unfortunately, there are two problems that must be worked around. First, there is a limited amount of group
 shared memory and a limited number of threads in a group. And second, in CS4.0, the group shared memory supports random access reads but it does not support random access writes. Even with these limitations, it is possible to create an efficient implementation
 using group shared memory.</p>
<p>Step 1: Load the group shared memory. Each thread loads one element.</p>
<p>&nbsp;&nbsp;&nbsp; <code>shared_data[GI] = Data[DTid.x];</code></p>
<p><br>
Step 2: Next, the threads must by synchronized to guarantee that all of the elements are loaded because the next operation will perform a random access read.</p>
<p>&nbsp;&nbsp;&nbsp; <code>GroupMemoryBarrierWithGroupSync();</code></p>
<p><br>
Step 3: Now each thread must pick the min or max of the two elements it is comparing. The thread cannot compare and swap both elements because that would require random access writes.</p>
<p>&nbsp;&nbsp;&nbsp; <code>unsigned int result = ((shared_data[GI &amp; ~j] &lt;= shared_data[GI | j]) == (bool)(g_iLevelMask &amp; DTid.x))? shared_data[GI ^ j] : shared_data[GI];</code></p>
<p><br>
Step 4: Again, the threads must be synchronized. This is to prevent any threads from performing the write operation before all threads have completed the read.</p>
<p>&nbsp;&nbsp;&nbsp; <code>GroupMemoryBarrierWithGroupSync();</code></p>
<p><br>
Step 5: The min or max is now stored in group shared memory and synchronized. (The algorithm loops back to step 3 and must finish all writes before threads start reading.)</p>
<p>&nbsp;&nbsp;&nbsp; <code>shared_data[GI] = result;<br>
&nbsp;&nbsp;&nbsp; GroupMemoryBarrierWithGroupSync();</code></p>
<p><br>
Step 6: With the memory sorted, the results can be stored back to the buffer.</p>
<p>&nbsp;&nbsp;&nbsp; <code>Data[DTid.x] = shared_data[GI];</code></p>
<h4>Sorting More Data&nbsp;</h4>
<p>The bitonic sort shader we have created works great when the data set is small enough to run with one thread group. Unfortunately, for CS4.0, this means a maximum of 512 elements, which is the largest power of 2 number of threads in a group. To solve this,
 we can add two additional steps to the algorithm. When we need to sort a section that is too large to be processed by a single group of threads, we transpose the entire data set. With the data transposed, larger sort steps can be performed entirely in shared
 memory without changing the bitonic sort algorithm. Once the large steps are completed, the data can be transposed back to complete the smaller steps of the sort.</p>
<h4>Transpose</h4>
<p>Implementing a transpose in Compute Shader is simple, but making it efficient requires a little bit of care. For best memory performance, it is preferable to access memory in a nice linear and consecutive pattern. Reading a row of data from the source with
 multiple threads is naturally a linear memory access. However, when that row is written to the destination as a column, the writes are no longer consecutive in memory. To achieve the best performance, a square block of data is first read into group shared
 memory as multiple contiguous memory reads. Then the shared memory is accessed as column data so that it can be written back as multiple contiguous memory writes. This allows us to shift the burden of the nonlinear access pattern to the high-performance group
 shared memory.</p>
<h1>Building with Visual Studio 2010</h1>
<p>The code in these samples can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
<ul>
<li>Change the Platform Toolset to &quot;v100&quot; </li><li>Obtain the <a href="http://msdn.microsoft.com/en-us/windows/hardware/hh852363">
Windows SDK 8.0</a> </li><li>Use the <a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
instructions </a>for adding the Windows 8.0 SDK headers for VS 2010 projects </li></ul>
<h1>Building with Visual Studio 2013</h1>
<p>Open the project with Visual Studio 2013 and upgrade the VC&#43;&#43; complier and libraries.&nbsp;</p>
<h1>Version History</h1>
<p>July 22, 2014 - Code review updates</p>
<p>September 17, 2013 - Original version cleaned up from DirectX SDK (June 2010) release</p>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2010/07/14/directcompute.aspx">DirectCompute</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:1391px; width:1px; height:1px; overflow:hidden">
</div>
