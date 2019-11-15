# Effects 11 Win32 Samples
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
- DirectX SDK
## Topics
- Graphics and 3D
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>This is the DirectX SDK's BasicHLSL10, DynamicShaderLinkageFX11, FixedFuncEMU, and Instancing10&nbsp;samples updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. These are samples Win32 desktop
 DirectX 11.0 applications for Windows 8, Windows 7, and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.&nbsp;</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop samples running on Windows Vista, Windows 7, and Windows 8. This is not intended for use with Windows Store apps or Windows RT.</strong></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>These samples use the&nbsp;<a href="http://go.microsoft.com/fwlink/?LinkId=320437">DXUT for Direct3D 11</a>&nbsp;framework and the
<a href="http://go.microsoft.com/fwlink/p/?LinkId=271568">Effects 11 library</a> for Win32 desktop applications.</p>
<h2>BasicHLSLFX11</h2>
<p><img id="96126" src="96126-basichlsl.jpg" alt="" width="90" height="71"></p>
<p>This sample loads a mesh, create vertex and pixel shaders from files, and then uses the shaders to render the mesh.</p>
<p><em>This is a Direct3D 11 version of the Direct3D 10 BasicHLSL10 sample. <a href="http://code.msdn.microsoft.com/Basic-DXUT-Win32-Samples-e59c0682">
BasicHLSL11</a> is a version of the same sample that does not make use of Effects 11.</em></p>
<h2>DynamicShaderLinkageFX11</h2>
<p><img id="96131" src="96131-dynamicshaderlinkagefx11.jpg" alt="" width="116" height="91"></p>
<p>This Direct3D 11 sample demonstrates use of Shader Model 5 shader interfaces and Direct3D 11 support for linking shader interface methods at runtime.</p>
<p><em>This is an Effects 11 version of the Direct3D 11 sample <a href="http://code.msdn.microsoft.com/Dynamic-Shader-Linkage-504eda2d">
DynamicShaderLinkage11</a>.</em>&nbsp;</p>
<h2>FixedFuncEMUFX11</h2>
<h2><img id="96132" src="96132-ffemu.jpg" alt="" width="200" height="150"></h2>
<p>This sample attempts to emulate certain aspects of the Direct3D 9 fixed function pipeline in a Direct3D 11 environment.</p>
<p><em>This is a Direct3D 11 version of the Direct3D 10 FixedFuncEMU sample.</em></p>
<h3>How the&nbsp;sample works</h3>
<ul>
<li>This sample attempts to emulate the following aspects of the Direct3D 9 fixed-function pipeline:
</li><li>Fixed-function Transformation Pipeline </li><li>Fixed-function Lighting Pipeline </li><li>AlphaTest </li><li>User Clip Planes </li><li>Pixel Fog </li><li>Gouraud and Flat shade modes </li><li>Projected texture lookups (texldp) </li><li>Multi-Texturing </li><li>D3DFILL_POINT fillmode </li><li>Screen space UI rendering </li></ul>
<h4>Fixed-function Transformation Pipeline</h4>
<p>The Direct3D 9 fixed-function transformation pipeline required 3 matrices to transform the raw points in 3d space into their 2d screen representations. These were the World, View, and Projection matrices. Instead of using SetTransform( D3DTS_WORLD, someMatrix
 ), we pass the matrices in as effect variables. The shader multiplies the input vertex positions by each of the World, View, and Projection matrices to get the same transformation that would have been produced by the fixed-function pipeline.</p>
<pre style="padding-left:30px">//output our final position in clipspace<br>float4 worldPos = mul( float4( input.pos, 1 ), g_mWorld );<br>float4 cameraPos = mul( worldPos, g_mView ); //Save cameraPos for fog calculations<br>output.pos = mul( cameraPos, g_mProj );</pre>
<h4>Fixed-function Lighting Pipeline</h4>
<pre style="padding-left:30px">ColorsOutput CalcLighting( float3 worldNormal, float3 worldPos, float3 cameraPos )<br>{<br>&nbsp;&nbsp;&nbsp; ColorsOutput output = (ColorsOutput)0.0;<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp; for(int i=0; i&lt;8; i&#43;&#43;)<br>&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; float3 toLight = g_lights[i].Position.xyz - worldPos;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; float lightDist = length( toLight );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; float fAtten = 1.0/dot( g_lights[i].Atten, float4(1,lightDist,lightDist*lightDist,0) );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; float3 lightDir = normalize( toLight );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; float3 halfAngle = normalize( normalize(-cameraPos) &#43; lightDir );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; output.Diffuse &#43;= max(0,dot( lightDir, worldNormal ) * g_lights[i].Diffuse * fAtten) &#43; g_lights[i].Ambient;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; output.Specular &#43;= max(0,pow( dot( halfAngle, worldNormal ), 64 ) * g_lights[i].Specular * fAtten );<br>&nbsp;&nbsp;&nbsp; }<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp; return output;<br>}</pre>
<h4>AlphaTest</h4>
<p>Alpha test is perhaps the simplest Direct3D 9 functionality to emulate. It does not require the user to set a alpha blend state. Instead the user can simply choose to discard a pixel based upon its alpha value. The following pixel shader does not draw the
 pixel if the alpha value is less than 0.5.</p>
<pre style="padding-left:30px">//<br>// PS for rendering with alpha test<br>//<br>float4 PSAlphaTestmain(PSSceneIn input) : COLOR0<br>{&nbsp;<br>&nbsp;float4 color =&nbsp; tex2D( g_samLinear, g_txDiffuse, input.tex ) * input.colorD;<br>&nbsp;if( color.a &lt; 0.5 )<br>&nbsp;&nbsp;discard;<br>&nbsp;return color;<br>}</pre>
<h4>User Clip Planes</h4>
<p>User Clip Planes are emulated by specifying a clip distance output from the Vertex Shader with the SV_ClipDistance[n] flag, where n is either 0 or 1. Each component can hold up to 4 clip distances in x, y, z, and w giving a total of 8 clip distances.</p>
<p>In this scenario, each clip planes is defined by a plane equation of the form: Ax&#43;By&#43;Cz&#43;D=0</p>
<p>Where &lt;A,B,C&gt; is the normal of the plane, and D is the distance of the plane from the origin. Plugging in any point &lt;x,y,z&gt; into this equation gives its distance from the plane. Therefore, all points &lt;x,y,z&gt; that satisfy the equation Ax
 &#43; By &#43; Cz &#43; D = 0 are on the plane. All points that satisfy Ax &#43; By &#43; Cz &#43; D &lt; 0 are below the plane. All points that satisfy Ax &#43; By &#43; Cz &#43; D &gt; 0 are above the plane.</p>
<p>In the Vertex Shader, each vertex is tested against each plane equation to produce a distance to the clip plane. Each of the three clip distances are stored in the first three components of the output component with the semantic SV_ClipDistance0. These clip
 distances get interpolated over the triangle during rasterization and clipped if the value every goes below 0.</p>
<h4>Pixel Fog</h4>
<p>Pixel fog uses a fog factor to determine how much a pixel is obscured by fog. In order to accurately calculate the fog factor, we must have the distance from the eye to the pixel being rendered. In Direct3D 9, this was approximated by using the Z-coordinate
 of a point that has been transformed by both the World and View matrices. In the vertex shader, this distance is stored in the fogDist member of the PSSceneIn struct for all 3 vertices of a triangle. It is then interpolated across the triangle during rasterization
 and passed to the pixel shader.</p>
<p>The pixel shader takes this fogDist value and passes it to the CalcFogFactor function which calculates the fog factor based upon the current value of g_fogMode.</p>
<pre style="padding-left:30px">//<br>// Calculates fog factor based upon distance<br>//<br>// E is defined as the base of the natural logarithm (2.71828)<br>float CalcFogFactor( float d )<br>{<br>&nbsp;float fogCoeff = 1.0;<br>&nbsp;<br>&nbsp;if( FOGMODE_LINEAR == g_fogMode )<br>&nbsp;{<br>&nbsp;&nbsp;fogCoeff = (g_fogEnd - d)/(g_fogEnd - g_fogStart);<br>&nbsp;}<br>&nbsp;else if( FOGMODE_EXP == g_fogMode )<br>&nbsp;{<br>&nbsp;&nbsp;fogCoeff = 1.0 / pow( E, d*g_fogDensity );<br>&nbsp;}<br>&nbsp;else if( FOGMODE_EXP2 == g_fogMode )<br>&nbsp;{<br>&nbsp;&nbsp;fogCoeff = 1.0 / pow( E, d*d*g_fogDensity*g_fogDensity );<br>&nbsp;}<br>&nbsp;<br>&nbsp;return clamp( fogCoeff, 0, 1 );<br>}</pre>
<p>Finally, the pixel shader uses the fog factor to determine how much of the original color and how much of the fog color to output to the pixel.</p>
<pre style="padding-left:30px">return fog * normalColor &#43; (1.0 - fog)*g_fogColor;</pre>
<h4><br>
Gouraud and Flat shade modes</h4>
<p>Gouraud shading involves calculating the color at the vertex of each triangle and interpolating it over the face of the triangle. By default Direct3D 11 uses D3D11_INTERPOLATION_MODE D3D11_INTERPOLATION_LINEAR to interpolate values over the face of a triangle
 during rasterization. Because of this, we can emulate Gouraud shading by calculating the lighting using Lambertian lighting ( dot( Normal, LightDir ) ) at each vertex and letting Direct3D 11 interpolate these values for us. By the time the color gets to the
 pixel shader, we simply use it as our lighting value and pass it through. No further work is needed.</p>
<p>Direct3D 11 also provides another way to interpolate data across a triangle, D3D11_INTERPOLATION_CONST. A naive approach would be to use this to calculate the color at the first vertex and allow that color to be spread across the entire face during rasterization.
 However, there is a problem with using this approach. Consider the case where the same sphere mesh needs to be rendered in both Gouraud and Flat shaded modes. To give the illusion of a faceted mesh being smooth, the normals at the vertices are averages of
 the normals of the adjacent faces. In short, on a sphere, no vertex will have a normal that is exactly perpendicular to any face it is a part of. For Gouraud shading, this is intentional. This is what allows the sphere to look smooth even though it is comprised
 of a finite number of polygons. However, for flat shading, this will give ill results.</p>
<p>D3D11_INTERPOLATION_CONST takes the value of the color calculated at the first vertex and spreads it across the entire triangle giving us shading that looks as if the normal was bent compared to the orientation of the triangle. A better method using the
 geometry shader to calculate the normal.</p>
<p>The second method gives more accurate results. The following code snippet illustrates how the geometry shader constructs a normal from the input world positions (wPos) of the triangle vertices. The lighting value is then calculated from this normal and spread
 to all vertices of the triangle.</p>
<pre style="padding-left:30px">//<br>// Calculate the face normal<br>//<br>float3 faceEdgeA = input[1].wPos - input[0].wPos;<br>float3 faceEdgeB = input[2].wPos - input[0].wPos;</pre>
<pre style="padding-left:30px">//<br>// Cross product<br>//<br>float3 faceNormal = cross(faceEdgeA, faceEdgeB);</pre>
<h4>Projected Texture Lookups</h4>
<p>Projected texturing simply divides the &lt;x,y,z&gt; coordinates of a 4d texture coordinate by the w coordinate before using it in a texture lookup operation. However, without the discussion of projected texturing, it becomes unclear why this functionality
 is useful.</p>
<p>Projecting a texture onto a surface can be easily illustrated by imagining how a projector works. The projector projects an image onto anything that happens to be in front of the projector. The same effect could be taken care of in the fixed-function pipeline
 by carefully setting up texture coordinate generation and texture stage states. In Direct3D 11, it is handled in shaders.</p>
<p>To tackle projected texturing, we must think about the problem in reverse. Instead of projecting a texture onto geometry, we simply render the geometry, and for each point, determine where that point would be hit by the projector texture. To do this, we
 only need to know the position of the point in world space as well as the view and projection matrices of the projector.</p>
<p>By multiplying the world space coordinate by the view and projection matrices of the light, we now have a point that is in the space of the projection of the light. Unfortunately, because we are converting this to texture coordinates, we would really like
 this point in some sort of [0..1] range. This is where the w coordinate comes into play. After the projection into the projector space, the w coordinate can be thought of as how much this vertex was scaled from a [-1..1] range to get to its current position.
 To get back to this [-1..1] range, we simply divide by the w coordinate. However, the projected texture is in the [0..1] range, so we must bias the result by halving it and adding 0.5.</p>
<pre style="padding-left:30px">//calculate the projected texture coordinate for the current world position<br>float4 cookieCoord = mul( float4(input.wPos,1), g_mLightViewProj );</pre>
<pre style="padding-left:30px">//since we don't have texldp, we must perform the w divide ourselves befor the texture lookup<br>cookieCoord.xy = 0.5 * cookieCoord.xy / cookieCoord.w &#43; float2( 0.5, 0.5 );</pre>
<h4>Multi-Texturing</h4>
<p>The texture stages from the fixed-function pipeline are officially gone. In there place is the ability to load textures arbitrarily in the pixel shader and to combine them in any way that the math operations of the language allow. The FixedFuncEMU sample
 emulates the D3DTOP_ADD texture blending operation. The first color is loaded from the diffuse texture at the texture coordinates defined in the mesh and multiplied by the input color.</p>
<pre style="padding-left:30px">float4 normalColor = tex2D( g_samLinear, g_txDiffuse, input.tex ) * input.colorD &#43; input.colorS;</pre>
<p>The second color is loaded from the projected texture using the projected coordinates described above.</p>
<pre style="padding-left:30px">cookieColor = tex2D( g_samLinear, g_txProjected, cookieCoord.xy );</pre>
<p>D3DTOP_ADD is simply emulated by adding the projected cookie texture to the normal texture color</p>
<pre style="padding-left:30px">normalColor &#43;= cookieColor;</pre>
<p>For D3DTOP_MODULATE, the shader would simply multiply the colors together instead of adding them. The effects file can also be extended to handle traditional lightmapping pipeline by passing a second set of texture coordinates stored in the mesh all the
 way down the pixel shader. The shader would then lookup into a lightmap texture using the second set of texture coordinates instead of the projected coordinates.</p>
<h4>Screen space UI rendering</h4>
<p>Rendering objects in screen space in Direct3D 11 requires that the user scale and bias the input screen coordinates against the viewport size. For example, a screen space coordinate in the range of &lt;[0..639],[0..479]&gt; needs to be transformed into the
 range of &lt;[-1..1],[-1..1]&gt;. So that it can be transformed back by the viewport transform.</p>
<p>The vertex shader code below performs this transformation. Note that the w coordinate of the position is explicitly set to 1. This ensures that the coordinates will remain the same when the w-divide occurs. Additionally, the Z position is passed into the
 shader in clip-space, meaning that it is in the [0..1] range, where 0 represents the near plane, and 1 represents the far plane.</p>
<pre style="padding-left:30px">//output our final position<br>output.pos.x = (input.pos.x / (g_viewportWidth/2.0)) -1;<br>output.pos.y = -(input.pos.y / (g_viewportHeight/2.0)) &#43;1;<br>output.pos.z = input.pos.z;<br>output.pos.w = 1;</pre>
<h4>D3DFILL_POINT fillmode</h4>
<p>The emulation of point fillmode requires the use of the geometry shader to turn one triangle of 3 vertices into 6 triangles of 12 vertices. For each vertex of the input triangle, the geometry shader emits 4 vertices that comprise a two-triangle strip at
 that position. The positions of these vertices are displaced such that the screen-space size in pixels is equal to the g_pointSize variable.</p>
<p>This sample does not show how to emulate point sprite functionality, which is closely related to point rendering.</p>
<h2>InstancingFX11</h2>
<p><img id="121875" src="http://i1.code.msdn.s-msft.com/effects-11-win32-samples-cce82a4d/image/file/121875/1/instancing.jpg" alt="" width="200" height="150"></p>
<p><em><strong>This is the Direct3D 10 Instancing sample updated for Direct3D 11.</strong></em></p>
<p>Reducing the number of draw calls made in any given frame is one way to improve graphics performance for a 3D application. The need for multiple draw calls in a scene arises from the different states required by different parts of the scene. These states
 often include matrices and material properties. One way to combat these issues is to use Instancing and Texture Arrays. In this sample, instancing enables the application to draw the same object multiple times in multiple places without the need for the CPU
 to update the world matrix for each object. Texture arrays allow multiple textures to be loaded into same resource and to be indexed by an extra texture coordinate, thus eliminating the need to change texture resources when a new object is drawn.</p>
<p>The sample draws several trees, each with many leaves, and several blades of grass using 3 draw calls. To achieve this, the sample uses one tree mesh, one leaf mesh, and one blade mesh instanced many time throughout the scene and drawn with DrawIndexedInstanced.
 To achieve variation in the leaf and grass appearance, texture arrays are used to hold different textures for both the leaf and grass instances. AlphaToCoverage allows the sample to further unburden the CPU and draw the leaves and blades of grass in no particular
 order. The rest of the environment is drawn in 6 draw calls.</p>
<h3>Instancing the Island and the Tree</h3>
<p>In order to replicate an island or a tree the sample needs two pieces of information. The first is the mesh information. In this case, the tree mesh is loaded from tree.sdkmesh and the island mesh is loaded from island.sdkmesh. The second piece of information
 is a buffer containing a list of matrices that describe the locations of all tree instances. In this case, an array of 4x4 D3DMATRIX structures is defined and translated using random position and scaling data with the sample's CreateRandomTreeMatrices()function.</p>
<p>The sample uses IASetVertexBuffers to bind the mesh information to vertex stream 0 and the matrices to stream 1:</p>
<pre>ID3D11Buffer* pVB[2];<br>pVB[0] = g_MeshTree.GetVB11( 0, 0 );<br>pVB[1] = g_pTreeInstanceData;<br>Strides[0] = ( UINT )g_MeshTree.GetVertexStride( 0, 0 );<br>Strides[1] = sizeof( D3DXMATRIX );<br>pd3dDevice-&gt;IASetVertexBuffers( 0, 2, pVB, Strides, Offsets );</pre>
<pre>To get this information into the shader correctly, the following InputLayout is used:</pre>
<pre>const D3D11_INPUT_ELEMENT_DESC instlayout[] =<br>{<br>&nbsp;&nbsp;&nbsp; { L&quot;POSITION&quot;, 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },<br>&nbsp;&nbsp;&nbsp; { L&quot;NORMAL&quot;, 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },<br>&nbsp;&nbsp;&nbsp; { L&quot;TEXTURE0&quot;, 0, DXGI_FORMAT_R32G32_FLOAT, 0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 0, D3D11_INPUT_PER_INSTANCE_DATA, 1 },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 1, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 16, D3D11_INPUT_PER_INSTANCE_DATA, 1 },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 2, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 32, D3D11_INPUT_PER_INSTANCE_DATA, 1 },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 3, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 48, D3D11_INPUT_PER_INSTANCE_DATA, 1 },<br>};</pre>
<p>The vertex shader will be called (number of vertices in mesh)*(number of instance matrices) times. Because the matrix is a shader input, the shader can position the vertex at the correct location according to which instance it happens to be processing.</p>
<h3>Instancing the Leaves</h3>
<p>Because one leaf is instanced over an entire tree and one tree is instanced several times throughout the sample, the leaves must be handled differently than the tree and grass meshes. The matrices for the trees are loaded into a constant buffer. The InputLayout
 is setup to make sure the shader sees the leaf mesh data m_iNumTreeInstances time before stepping to the next leaf matrix. The last element, fOcc, is a baked occlusion term used to shade the leaves.</p>
<pre>const D3D11_INPUT_ELEMENT_DESC leaflayout[] =<br>{<br>&nbsp;&nbsp;&nbsp; { L&quot;POSITION&quot;, 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },<br>&nbsp;&nbsp;&nbsp; { L&quot;TEXTURE0&quot;, 0, DXGI_FORMAT_R32G32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 0, D3D11_INPUT_PER_INSTANCE_DATA, m_iNumTreeInstances },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 1, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 16, D3D11_INPUT_PER_INSTANCE_DATA, m_iNumTreeInstances },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 2, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 32, D3D11_INPUT_PER_INSTANCE_DATA, m_iNumTreeInstances },<br>&nbsp;&nbsp;&nbsp; { L&quot;mTransform&quot;, 3, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 48, D3D11_INPUT_PER_INSTANCE_DATA, m_iNumTreeInstances },<br>&nbsp;&nbsp;&nbsp; { L&quot;fOcc&quot;, 0, DXGI_FORMAT_R32_FLOAT, 1, 64, D3D11_INPUT_PER_INSTANCE_DATA, m_iNumTreeInstances },<br>};</pre>
<p>The input assembler automatically generates an InstanceID which can be passed into the shader. The following snippet of shader code demonstrates how the leaves are positioned.</p>
<pre>&nbsp;&nbsp;&nbsp; int iTree = input.InstanceId%g_iNumTrees;<br>&nbsp;&nbsp;&nbsp; float4 vInstancePos = mul( float4(input.pos, 1), input.mTransform&nbsp; );<br>&nbsp;&nbsp;&nbsp; float4 InstancePosition = mul(vInstancePos, g_mTreeMatrices[iTree] );</pre>
<p>If there were 3 trees in the scene, the leaves would be drawn in the following order: Tree1, leaf1; Tree2, leaf1; Tree3, leaf1; Tree1, leaf2; Tree2, leaf2; etc...</p>
<h3>Instancing the Grass</h3>
<p>Grass rendering is handled differently than the Tree and Leaves. Instead of using the input assembler to instance the grass using a separate stream of matrices, the grass is dynamically generated in the geometry shader. The top of the island mesh is passed
 to the vertex shader, which passes this information directly to the GSGrassmain geometry shader. Depending on the grass density specified, the GSGrassmain calculates psuedo-random positions on the current triangle that correspond to grass positions. These
 positions are then passed to a helper function that creates a blade of grass at the point. A 1D texture of random floating point values is used to provide the psuedo-random numbers. It is indexed by vertex ids of the input mesh. This ensures that the random
 distribution doesn't change from frame to frame.</p>
<p>Alternatively, the grass can be rendered in the same way as the tree by placing the vertices of a quad into the first vertex stream and the matrices for each blade of grass in the second vertex stream. The fOcc element of the second stream can be used to
 place precalculated shadows on the blades of grass (just as it is used to precalculate shadows on the leaves). However, the storage space for a stream of several hundred thousand matrices is a concern even on modern graphics hardware. The grass generation
 method of using the geometry shader, while lacking built-in shadows, uses far less storage.</p>
<h3>Changing Leaves with Texture Arrays</h3>
<p>Texture arrays are just what the name implies. They are arrays of textures, each with full mipmaps. For a texture2D array, the array is indexed by the z coordinate. Because the InstanceID is passed into the shader, the sample uses InstanceID%numArrayIndices
 to determine which texture in the array to use for rendering that specific leaf or blade of grass.</p>
<h3>Drawing Transparent Objects with Alpha To Coverage</h3>
<p>The number of transparent leave and blades of grass in the sample makes sorting these objects on the CPU expensive. Alpha to coverage helps solve this problem by allowing the Instancing sample to produce convincing results without the need to sort leaves
 and grass back to front. Alpha to coverage must be used with multisample anti-aliasing (MSAA). MSAA is a method to get edge anti-aliasing by evaluating triangle coverage at a higher-frequency on a higher resolution z-buffer. With alpha to coverage, the MSAA
 mechanism can be tricked into creating psuedo order independent transparency. Alpha to coverage generates a MSAA coverage mask for a pixel based upon the pixel shader output alpha. That result is combined by AND with the coverage mask for the triangle. This
 process is similar to screen-door transparency, but at the MSAA level.</p>
<p>Alpha to coverage is not designed for true order independent transparency like windows, but works great for cases where alpha is being used to represent coverage, like in a mipmapped leaf texture.</p>
<h1>Dependancies</h1>
<p>DXUT-based samples typically make use of runtime HLSL compilation. Build-time compilation is recommended for all production Direct3D applications, but for experimentation and samples development runtime HLSL compiliation is preferred. The Effects 11 library
 also needs to make use of shader reflection APIs at runtime. Therefore, the D3DCompile*.DLL must be available in the search path when these programs are executed.</p>
<ul>
<li>When using the Windows 8.x SDK and targeting Windows Vista or later, you can include the D3DCompile_46 or D3DCompile_47 DLL side-by-side with your application copying the file from the REDIST folder.
</li></ul>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.0\Redist\D3D\arm, x86 or x64</pre>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.1\Redist\D3D\arm, x86 or x64</pre>
<h1>Building with Visual Studio 2010</h1>
<p>The code in these samples can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
<ul>
<li>Change the Platform Toolset to &quot;v100&quot; </li><li>Obtain the <a href="http://msdn.microsoft.com/en-us/windows/hardware/hh852363">
Windows SDK 8.0</a> </li><li>Use the <a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
instructions </a>for adding the Windows 8.0 SDK headers for VS 2010 projects </li></ul>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using hte Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DXUT and Effects 11 packages. Remove the &quot;DXUT_2012.vcxproj&quot;, &quot;DXUTOpt_2012.vcxproj&quot;
 &amp; &quot;Effects11_2012.vcxproj&quot; references, add the projects &quot;DXUT_2013.vcxproj&quot;, &quot;DXUTOpt_2013.vcxproj&quot; &amp; &quot;Effects11_2013.vcxproj&quot;, and add new References to these projects.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<ul>
<li>July 28, 2014 - Updated for July 2014 releases of DXUT 11.06 and Effects 11 (11.10), added InstancingFX11 sample
</li><li>September 16, 2013 - Initial release </li></ul>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/10/24/effects-for-direct3d-11-update.aspx">Effects for Direct3D 11 Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
