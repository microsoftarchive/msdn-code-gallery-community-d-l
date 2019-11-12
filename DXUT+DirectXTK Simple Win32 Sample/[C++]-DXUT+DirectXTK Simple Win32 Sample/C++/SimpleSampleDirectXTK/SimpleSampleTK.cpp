//--------------------------------------------------------------------------------------
// File: SimpleSampleTK.cpp
//
// Starting point for new Direct3D 11 Win32 desktop samples using DirectX Tool Kit
// and DXUT.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//--------------------------------------------------------------------------------------
#include "DXUT.h"
#include "DXUTgui.h"
#include "DXUTmisc.h"
#include "DXUTCamera.h"
#include "DXUTSettingsDlg.h"
#include "SDKmisc.h"
#include "resource.h"

#include "CommonStates.h"
#include "DDSTextureLoader.h"
#include "Effects.h"
#include "GeometricPrimitive.h"
#include "Model.h"
#include "PrimitiveBatch.h"
#include "ScreenGrab.h"
#include "SpriteBatch.h"
#include "SpriteFont.h"
#include "VertexTypes.h"

#pragma warning( disable : 4100 )

using namespace DirectX;

//--------------------------------------------------------------------------------------
class MyEffectFactory : public EffectFactory
{
public:
    MyEffectFactory( _In_ ID3D11Device* device ) : EffectFactory( device ) { *searchPath = 0; }

    virtual void __cdecl CreateTexture( _In_z_ const WCHAR* name, _In_opt_ ID3D11DeviceContext* deviceContext, _Outptr_ ID3D11ShaderResourceView** textureView ) override
    {
        WCHAR fname[MAX_PATH] = {0};
        if ( *searchPath )
            wcscpy_s( fname, searchPath );
        wcscat_s( fname, name );

        WCHAR path[MAX_PATH] = {0};
        if ( FAILED( DXUTFindDXSDKMediaFileCch( path, MAX_PATH, fname ) ) )
        {
            throw std::exception("Media not found");
        }

        EffectFactory::CreateTexture( path, deviceContext, textureView );
    }

    void SetPath( const WCHAR* path ) { if ( path ) { wcscpy_s( searchPath, path ); } else { *searchPath = 0; } }

private:
    WCHAR searchPath[ MAX_PATH ];
};

//--------------------------------------------------------------------------------------
// Global variables
//--------------------------------------------------------------------------------------
CModelViewerCamera          g_Camera;               // A model viewing camera
CDXUTDialogResourceManager  g_DialogResourceManager; // manager for shared resources of dialogs
CD3DSettingsDlg             g_SettingsDlg;          // Device settings dialog
CDXUTTextHelper*            g_pTxtHelper = nullptr;
CDXUTDialog                 g_HUD;                  // dialog for standard controls
CDXUTDialog                 g_SampleUI;             // dialog for sample specific controls

ID3D11ShaderResourceView*           g_pTextureRV1 = nullptr;
ID3D11ShaderResourceView*           g_pTextureRV2 = nullptr;
ID3D11InputLayout*                  g_pBatchInputLayout = nullptr;

std::unique_ptr<CommonStates>                           g_States;
std::unique_ptr<BasicEffect>                            g_BatchEffect;
std::unique_ptr<MyEffectFactory>                        g_FXFactory;
std::unique_ptr<GeometricPrimitive>                     g_Shape;
std::unique_ptr<Model>                                  g_Model;
std::unique_ptr<PrimitiveBatch<VertexPositionColor>>    g_Batch;
std::unique_ptr<SpriteBatch>                            g_Sprites;
std::unique_ptr<SpriteFont>                             g_Font;

//--------------------------------------------------------------------------------------
// UI control IDs
//--------------------------------------------------------------------------------------
#define IDC_TOGGLEFULLSCREEN    1
#define IDC_TOGGLEREF           2
#define IDC_CHANGEDEVICE        3
#define IDC_TOGGLEWARP          4

//--------------------------------------------------------------------------------------
// Forward declarations 
//--------------------------------------------------------------------------------------
LRESULT CALLBACK MsgProc( HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam, bool* pbNoFurtherProcessing,
                          void* pUserContext );
void CALLBACK OnKeyboard( UINT nChar, bool bKeyDown, bool bAltDown, void* pUserContext );
void CALLBACK OnGUIEvent( UINT nEvent, int nControlID, CDXUTControl* pControl, void* pUserContext );
void CALLBACK OnFrameMove( double fTime, float fElapsedTime, void* pUserContext );
bool CALLBACK ModifyDeviceSettings( DXUTDeviceSettings* pDeviceSettings, void* pUserContext );

bool CALLBACK IsD3D11DeviceAcceptable( const CD3D11EnumAdapterInfo *AdapterInfo, UINT Output,
                                       const CD3D11EnumDeviceInfo *DeviceInfo,
                                       DXGI_FORMAT BackBufferFormat, bool bWindowed, void* pUserContext );
HRESULT CALLBACK OnD3D11CreateDevice( ID3D11Device* pd3dDevice, const DXGI_SURFACE_DESC* pBackBufferSurfaceDesc,
                                     void* pUserContext );
HRESULT CALLBACK OnD3D11ResizedSwapChain( ID3D11Device* pd3dDevice, IDXGISwapChain* pSwapChain,
                                         const DXGI_SURFACE_DESC* pBackBufferSurfaceDesc, void* pUserContext );
void CALLBACK OnD3D11ReleasingSwapChain( void* pUserContext );
void CALLBACK OnD3D11DestroyDevice( void* pUserContext );
void CALLBACK OnD3D11FrameRender( ID3D11Device* pd3dDevice, ID3D11DeviceContext* pd3dImmediateContext, double fTime,
                                 float fElapsedTime, void* pUserContext );

void InitApp();
void RenderText();
void DrawGrid( FXMVECTOR xAxis, FXMVECTOR yAxis, FXMVECTOR origin, size_t xdivs, size_t ydivs, GXMVECTOR color );

//--------------------------------------------------------------------------------------
// Entry point to the program. Initializes everything and goes into a message processing 
// loop. Idle time is used to render the scene.
//--------------------------------------------------------------------------------------
int WINAPI wWinMain( _In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR lpCmdLine, _In_ int nCmdShow )
{
    // Enable run-time memory check for debug builds.
#if defined(DEBUG) | defined(_DEBUG)
    _CrtSetDbgFlag( _CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF );
#endif

    // DXUT will create and use the best device
    // that is available on the system depending on which D3D callbacks are set below

    // Set DXUT callbacks
    DXUTSetCallbackMsgProc( MsgProc );
    DXUTSetCallbackKeyboard( OnKeyboard );
    DXUTSetCallbackFrameMove( OnFrameMove );
    DXUTSetCallbackDeviceChanging( ModifyDeviceSettings );

    DXUTSetCallbackD3D11DeviceAcceptable( IsD3D11DeviceAcceptable );
    DXUTSetCallbackD3D11DeviceCreated( OnD3D11CreateDevice );
    DXUTSetCallbackD3D11SwapChainResized( OnD3D11ResizedSwapChain );
    DXUTSetCallbackD3D11SwapChainReleasing( OnD3D11ReleasingSwapChain );
    DXUTSetCallbackD3D11DeviceDestroyed( OnD3D11DestroyDevice );
    DXUTSetCallbackD3D11FrameRender( OnD3D11FrameRender );

    InitApp();
    DXUTInit( true, true, nullptr ); // Parse the command line, show msgboxes on error, no extra command line params
    DXUTSetCursorSettings( true, true );
    DXUTCreateWindow( L"SimpleSample for DirectXTK" );

    // Only require 10-level hardware, change to D3D_FEATURE_LEVEL_11_0 to require 11-class hardware
    // Switch to D3D_FEATURE_LEVEL_9_x for 10level9 hardware
    DXUTCreateDevice( D3D_FEATURE_LEVEL_10_0, true, 800, 600 );

    DXUTMainLoop(); // Enter into the DXUT render loop

    return DXUTGetExitCode();
}


//--------------------------------------------------------------------------------------
// Initialize the app 
//--------------------------------------------------------------------------------------
void InitApp()
{
    g_SettingsDlg.Init( &g_DialogResourceManager );
    g_HUD.Init( &g_DialogResourceManager );
    g_SampleUI.Init( &g_DialogResourceManager );

    g_HUD.SetCallback( OnGUIEvent );
    int iY = 30;
    int iYo = 26;
    g_HUD.AddButton( IDC_TOGGLEFULLSCREEN, L"Toggle full screen", 0, iY, 170, 22 );
    g_HUD.AddButton( IDC_CHANGEDEVICE, L"Change device (F2)", 0, iY += iYo, 170, 22, VK_F2 );
    g_HUD.AddButton( IDC_TOGGLEREF, L"Toggle REF (F3)", 0, iY += iYo, 170, 22, VK_F3 );
    g_HUD.AddButton( IDC_TOGGLEWARP, L"Toggle WARP (F4)", 0, iY += iYo, 170, 22, VK_F4 );

    g_SampleUI.SetCallback( OnGUIEvent ); iY = 10;
}


//--------------------------------------------------------------------------------------
// Render the help and statistics text.
//--------------------------------------------------------------------------------------
void RenderText()
{
    g_pTxtHelper->Begin();
    g_pTxtHelper->SetInsertionPos( 5, 5 );
    g_pTxtHelper->SetForegroundColor( Colors::Yellow );
    g_pTxtHelper->DrawTextLine( DXUTGetFrameStats( DXUTIsVsyncEnabled() ) );
    g_pTxtHelper->DrawTextLine( DXUTGetDeviceStats() );
    g_pTxtHelper->End();
}


//--------------------------------------------------------------------------------------
void DrawGrid( FXMVECTOR xAxis, FXMVECTOR yAxis, FXMVECTOR origin, size_t xdivs, size_t ydivs, GXMVECTOR color )
{
    auto context = DXUTGetD3D11DeviceContext();
    g_BatchEffect->Apply( context );

    context->IASetInputLayout( g_pBatchInputLayout );

    g_Batch->Begin();

    xdivs = std::max<size_t>( 1, xdivs );
    ydivs = std::max<size_t>( 1, ydivs );

    for( size_t i = 0; i <= xdivs; ++i )
    {
        float fPercent = float(i) / float(xdivs);
        fPercent = ( fPercent * 2.0f ) - 1.0f;
        XMVECTOR vScale = XMVectorScale( xAxis, fPercent );
        vScale = XMVectorAdd( vScale, origin );

        VertexPositionColor v1( XMVectorSubtract( vScale, yAxis ), color );
        VertexPositionColor v2( XMVectorAdd( vScale, yAxis ), color );
        g_Batch->DrawLine( v1, v2 );
    }

    for( size_t i = 0; i <= ydivs; i++ )
    {
        FLOAT fPercent = float(i) / float(ydivs);
        fPercent = ( fPercent * 2.0f ) - 1.0f;
        XMVECTOR vScale = XMVectorScale( yAxis, fPercent );
        vScale = XMVectorAdd( vScale, origin );

        VertexPositionColor v1( XMVectorSubtract( vScale, xAxis ), color );
        VertexPositionColor v2( XMVectorAdd( vScale, xAxis ), color );
        g_Batch->DrawLine( v1, v2 );
    }

    g_Batch->End();
}


//--------------------------------------------------------------------------------------
// Reject any D3D11 devices that aren't acceptable by returning false
//--------------------------------------------------------------------------------------
bool CALLBACK IsD3D11DeviceAcceptable( const CD3D11EnumAdapterInfo *AdapterInfo, UINT Output,
                                       const CD3D11EnumDeviceInfo *DeviceInfo,
                                       DXGI_FORMAT BackBufferFormat, bool bWindowed, void* pUserContext )
{
    return true;
}


//--------------------------------------------------------------------------------------
// Create any D3D11 resources that aren't dependant on the back buffer
//--------------------------------------------------------------------------------------
HRESULT CALLBACK OnD3D11CreateDevice( ID3D11Device* pd3dDevice, const DXGI_SURFACE_DESC* pBackBufferSurfaceDesc,
                                     void* pUserContext )
{
    HRESULT hr;

    auto pd3dImmediateContext = DXUTGetD3D11DeviceContext();
    V_RETURN( g_DialogResourceManager.OnD3D11CreateDevice( pd3dDevice, pd3dImmediateContext ) );
    V_RETURN( g_SettingsDlg.OnD3D11CreateDevice( pd3dDevice ) );
    g_pTxtHelper = new CDXUTTextHelper( pd3dDevice, pd3dImmediateContext, &g_DialogResourceManager, 15 );

    // Create other render resources here
    g_States.reset( new CommonStates( pd3dDevice ) );
    g_Sprites.reset( new SpriteBatch( pd3dImmediateContext ) );
    g_FXFactory.reset( new MyEffectFactory( pd3dDevice ) );
    g_Batch.reset( new PrimitiveBatch<VertexPositionColor>( pd3dImmediateContext ) );

    g_BatchEffect.reset( new BasicEffect( pd3dDevice ) );
    g_BatchEffect->SetVertexColorEnabled(true);

    {
        void const* shaderByteCode;
        size_t byteCodeLength;

        g_BatchEffect->GetVertexShaderBytecode( &shaderByteCode, &byteCodeLength );

        hr = pd3dDevice->CreateInputLayout( VertexPositionColor::InputElements,
                                            VertexPositionColor::InputElementCount,
                                            shaderByteCode, byteCodeLength,
                                            &g_pBatchInputLayout );
        if( FAILED( hr ) )
            return hr;
    }

    WCHAR str[ MAX_PATH ];
    V_RETURN( DXUTFindDXSDKMediaFileCch( str, MAX_PATH, L"UI\\italic.spritefont" ) );
    g_Font.reset( new SpriteFont( pd3dDevice, str ) );

    g_Shape = GeometricPrimitive::CreateTeapot( pd3dImmediateContext, 4.f, 8, false );

    V_RETURN( DXUTFindDXSDKMediaFileCch( str, MAX_PATH, L"Tiny\\tiny.sdkmesh" ) );
    g_FXFactory->SetPath( L"Tiny\\" );
    g_Model = Model::CreateFromSDKMESH( pd3dDevice, str, *g_FXFactory, true );

    // Load the Texture
    V_RETURN( DXUTFindDXSDKMediaFileCch( str, MAX_PATH, L"misc\\seafloor.dds" ) );
    hr = CreateDDSTextureFromFile( pd3dDevice, str, nullptr, &g_pTextureRV1 );
    if( FAILED( hr ) )
        return hr;

    V_RETURN( DXUTFindDXSDKMediaFileCch( str, MAX_PATH, L"misc\\windowslogo.dds" ) );
    hr = CreateDDSTextureFromFile( pd3dDevice, str, nullptr, &g_pTextureRV2 );
    if( FAILED( hr ) )
        return hr;

    // Setup the camera's view parameters
    static const XMVECTORF32 s_vecEye = { 0.0f, 3.0f, -6.0f, 0.f };
    g_Camera.SetViewParams( s_vecEye, g_XMZero );

    g_HUD.GetButton( IDC_TOGGLEWARP )->SetEnabled( true );

    return S_OK;
}


//--------------------------------------------------------------------------------------
// Create any D3D11 resources that depend on the back buffer
//--------------------------------------------------------------------------------------
HRESULT CALLBACK OnD3D11ResizedSwapChain( ID3D11Device* pd3dDevice, IDXGISwapChain* pSwapChain,
                                         const DXGI_SURFACE_DESC* pBackBufferSurfaceDesc, void* pUserContext )
{
    HRESULT hr;

    V_RETURN( g_DialogResourceManager.OnD3D11ResizedSwapChain( pd3dDevice, pBackBufferSurfaceDesc ) );
    V_RETURN( g_SettingsDlg.OnD3D11ResizedSwapChain( pd3dDevice, pBackBufferSurfaceDesc ) );

    // Setup the camera's projection parameters
    float fAspectRatio = pBackBufferSurfaceDesc->Width / ( FLOAT )pBackBufferSurfaceDesc->Height;
    g_Camera.SetProjParams( XM_PI / 4, fAspectRatio, 0.1f, 1000.0f );
    g_Camera.SetWindow( pBackBufferSurfaceDesc->Width, pBackBufferSurfaceDesc->Height );
    g_Camera.SetButtonMasks( MOUSE_LEFT_BUTTON, MOUSE_WHEEL, MOUSE_MIDDLE_BUTTON );

    g_HUD.SetLocation( pBackBufferSurfaceDesc->Width - 170, 0 );
    g_HUD.SetSize( 170, 170 );
    g_SampleUI.SetLocation( pBackBufferSurfaceDesc->Width - 170, pBackBufferSurfaceDesc->Height - 300 );
    g_SampleUI.SetSize( 170, 300 );

    return S_OK;
}


//--------------------------------------------------------------------------------------
// Render the scene using the D3D11 device
//--------------------------------------------------------------------------------------
void CALLBACK OnD3D11FrameRender( ID3D11Device* pd3dDevice, ID3D11DeviceContext* pd3dImmediateContext, double fTime,
                                 float fElapsedTime, void* pUserContext )
{
    // If the settings dialog is being shown, then render it instead of rendering the app's scene
    if( g_SettingsDlg.IsActive() )
    {
        g_SettingsDlg.OnRender( fElapsedTime );
        return;
    }       

    auto pRTV = DXUTGetD3D11RenderTargetView();
    pd3dImmediateContext->ClearRenderTargetView( pRTV, Colors::MidnightBlue );

    // Clear the depth stencil
    auto pDSV = DXUTGetD3D11DepthStencilView();
    pd3dImmediateContext->ClearDepthStencilView( pDSV, D3D11_CLEAR_DEPTH, 1.0, 0 );

    // Get the projection & view matrix from the camera class
    XMMATRIX mWorld = g_Camera.GetWorldMatrix();
    XMMATRIX mView = g_Camera.GetViewMatrix();
    XMMATRIX mProj = g_Camera.GetProjMatrix();

    g_BatchEffect->SetView( mView );
    g_BatchEffect->SetProjection( mProj );

    // Draw procedurally generated dynamic grid
    const XMVECTORF32 xaxis = { 20.f, 0.f, 0.f };
    const XMVECTORF32 yaxis = { 0.f, 0.f, 20.f };
    DrawGrid( xaxis, yaxis, g_XMZero, 20, 20, Colors::Gray );

    // Draw sprite
    g_Sprites->Begin( SpriteSortMode_Deferred );
    g_Sprites->Draw( g_pTextureRV2, XMFLOAT2(10, 75 ), nullptr, Colors::White );

    g_Font->DrawString( g_Sprites.get(), L"DirectXTK Simple Sample", XMFLOAT2( 100, 350 ), Colors::Yellow );
    g_Sprites->End();

    // Draw 3D object
    XMMATRIX local = XMMatrixMultiply( mWorld, XMMatrixTranslation( -2.f, -2.f, 4.f ) );
    g_Shape->Draw( local, mView, mProj, Colors::White, g_pTextureRV1 );

    XMVECTOR qid = XMQuaternionIdentity();
    const XMVECTORF32 scale = { 0.01f, 0.01f, 0.01f};
    const XMVECTORF32 translate = { 3.f, -2.f, 4.f };
    XMVECTOR rotate = XMQuaternionRotationRollPitchYaw( 0, XM_PI/2.f, XM_PI/2.f );
    local = XMMatrixMultiply( mWorld, XMMatrixTransformation( g_XMZero, qid, scale, g_XMZero, rotate, translate ) );
    g_Model->Draw( pd3dImmediateContext, *g_States, local, mView, mProj );

    // Render HUD
    DXUT_BeginPerfEvent( DXUT_PERFEVENTCOLOR, L"HUD / Stats" );
    g_HUD.OnRender( fElapsedTime );
    g_SampleUI.OnRender( fElapsedTime );
    RenderText();
    DXUT_EndPerfEvent();

    static ULONGLONG timefirst = GetTickCount64();
    if ( GetTickCount64() - timefirst > 5000 )
    {    
        OutputDebugString( DXUTGetFrameStats( DXUTIsVsyncEnabled() ) );
        OutputDebugString( L"\n" );
        timefirst = GetTickCount64();
    }
}


//--------------------------------------------------------------------------------------
// Release D3D11 resources created in OnD3D11ResizedSwapChain 
//--------------------------------------------------------------------------------------
void CALLBACK OnD3D11ReleasingSwapChain( void* pUserContext )
{
    g_DialogResourceManager.OnD3D11ReleasingSwapChain();
}


//--------------------------------------------------------------------------------------
// Release D3D11 resources created in OnD3D11CreateDevice 
//--------------------------------------------------------------------------------------
void CALLBACK OnD3D11DestroyDevice( void* pUserContext )
{
    g_DialogResourceManager.OnD3D11DestroyDevice();
    g_SettingsDlg.OnD3D11DestroyDevice();
    DXUTGetGlobalResourceCache().OnDestroyDevice();
    SAFE_DELETE( g_pTxtHelper );

    g_States.reset();
    g_BatchEffect.reset();
    g_FXFactory.reset();
    g_Shape.reset();
    g_Model.reset();
    g_Batch.reset();
    g_Sprites.reset();
    g_Font.reset();

    SAFE_RELEASE( g_pBatchInputLayout );

    SAFE_RELEASE( g_pTextureRV1 );
    SAFE_RELEASE( g_pTextureRV2 );

    // Delete additional render resources here...
}


//--------------------------------------------------------------------------------------
// Called right before creating a D3D device, allowing the app to modify the device settings as needed
//--------------------------------------------------------------------------------------
bool CALLBACK ModifyDeviceSettings( DXUTDeviceSettings* pDeviceSettings, void* pUserContext )
{
    return true;
}


//--------------------------------------------------------------------------------------
// Handle updates to the scene.  This is called regardless of which D3D API is used
//--------------------------------------------------------------------------------------
void CALLBACK OnFrameMove( double fTime, float fElapsedTime, void* pUserContext )
{
    // Update the camera's position based on user input 
    g_Camera.FrameMove( fElapsedTime );
}


//--------------------------------------------------------------------------------------
// Handle messages to the application
//--------------------------------------------------------------------------------------
LRESULT CALLBACK MsgProc( HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam, bool* pbNoFurtherProcessing,
                          void* pUserContext )
{
    // Pass messages to dialog resource manager calls so GUI state is updated correctly
    *pbNoFurtherProcessing = g_DialogResourceManager.MsgProc( hWnd, uMsg, wParam, lParam );
    if( *pbNoFurtherProcessing )
        return 0;

    // Pass messages to settings dialog if its active
    if( g_SettingsDlg.IsActive() )
    {
        g_SettingsDlg.MsgProc( hWnd, uMsg, wParam, lParam );
        return 0;
    }

    // Give the dialogs a chance to handle the message first
    *pbNoFurtherProcessing = g_HUD.MsgProc( hWnd, uMsg, wParam, lParam );
    if( *pbNoFurtherProcessing )
        return 0;
    *pbNoFurtherProcessing = g_SampleUI.MsgProc( hWnd, uMsg, wParam, lParam );
    if( *pbNoFurtherProcessing )
        return 0;

    // Pass all remaining windows messages to camera so it can respond to user input
    g_Camera.HandleMessages( hWnd, uMsg, wParam, lParam );

    return 0;
}


//--------------------------------------------------------------------------------------
// Handle key presses
//--------------------------------------------------------------------------------------
void CALLBACK OnKeyboard( UINT nChar, bool bKeyDown, bool bAltDown, void* pUserContext )
{
}


//--------------------------------------------------------------------------------------
// Handles the GUI events
//--------------------------------------------------------------------------------------
void CALLBACK OnGUIEvent( UINT nEvent, int nControlID, CDXUTControl* pControl, void* pUserContext )
{
    switch( nControlID )
    {
        case IDC_TOGGLEFULLSCREEN:
            DXUTToggleFullScreen();
            break;
        case IDC_TOGGLEREF:
            DXUTToggleREF();
            break;
        case IDC_TOGGLEWARP:
            DXUTToggleWARP();
            break;
        case IDC_CHANGEDEVICE:
            g_SettingsDlg.SetActive( !g_SettingsDlg.IsActive() );
            break;
    }
}
