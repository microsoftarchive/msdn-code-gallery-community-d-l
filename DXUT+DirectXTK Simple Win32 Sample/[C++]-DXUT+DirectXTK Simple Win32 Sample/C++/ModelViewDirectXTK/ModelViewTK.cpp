//--------------------------------------------------------------------------------------
// File: ModelView.cpp
//
// Simple model viewer for .CMO and .SDKMESH
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
#include "Model.h"
#include "ScreenGrab.h"
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

std::unique_ptr<CommonStates>       g_States;
std::unique_ptr<MyEffectFactory>    g_FXFactory;
std::unique_ptr<Model>              g_Model;
std::wstring                        g_ModelStats;

//--------------------------------------------------------------------------------------
// UI control IDs
//--------------------------------------------------------------------------------------
#define IDC_TOGGLEFULLSCREEN    1
#define IDC_TOGGLEREF           2
#define IDC_CHANGEDEVICE        3
#define IDC_TOGGLEWARP          4
#define IDC_LOAD_MODEL          5
#define IDC_MESH_LIST           6
#define IDC_WIREFRAME           7

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
void UpdateForModel();
void SetViewForModel();

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
    DXUTCreateWindow( L"ModelView for DirectXTK" );

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

    g_SampleUI.SetCallback( OnGUIEvent ); iY = 26;

    g_SampleUI.AddButton( IDC_LOAD_MODEL, L"Load (M)odel", 0, iY, 170, 22, 'M' );

    g_SampleUI.AddCheckBox( IDC_WIREFRAME, L"Wireframe", 10, iY += iY, 170, 22 );

    g_SampleUI.AddComboBox( IDC_MESH_LIST, 0, iY += iYo*3, 170, 26 );
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

    if ( !g_ModelStats.empty() )
    {
        g_pTxtHelper->DrawTextLine( g_ModelStats.c_str() );
    }

    g_pTxtHelper->End();
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
void UpdateForModel()
{
    g_ModelStats.clear();

    if ( !g_Model )
        return;

    auto pComboBox = g_SampleUI.GetComboBox( IDC_MESH_LIST );
    if ( pComboBox )
    {
        pComboBox->RemoveAllItems();
        pComboBox->AddItem( L"<All>", IntToPtr( -1 ) );
    }

    int index = 0;
    size_t nfaces = 0;
    for ( auto mit = g_Model->meshes.cbegin(); mit != g_Model->meshes.cend(); ++mit, ++index )
    {
        for ( auto pit = (*mit)->meshParts.cbegin(); pit != (*mit)->meshParts.cend(); ++pit )
        {
            nfaces += ( (*pit)->indexCount - (*pit)->startIndex ) / 3;
        }

        if ( pComboBox )
        {
            pComboBox->AddItem( (*mit)->name.empty() ? L"<noname>" : (*mit)->name.c_str(), IntToPtr( index ) );
        }
    }

    wchar_t buff[ 80 ];
    swprintf_s( buff, L"Mesh count %u; faces %u", g_Model->meshes.size(), nfaces );
    g_ModelStats = buff;
}


//--------------------------------------------------------------------------------------
void SetViewForModel()
{
    BoundingSphere sphere( XMFLOAT3(0,0,0), 1.f );

    if ( g_Model )
    {
        for ( auto mit = g_Model->meshes.cbegin(); mit != g_Model->meshes.cend(); ++mit )
        {
            BoundingSphere::CreateMerged(sphere, sphere, (*mit)->boundingSphere );
        }
    }

    // Setup the camera's view parameters
    float v = (sphere.Radius > 1.f) ? -(sphere.Radius*2.f) : -6.f;
    XMVECTOR vecEye = XMVectorSet( 0.0f, v, v, 0.f );
    g_Camera.SetViewParams( vecEye, g_XMZero );
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
    g_FXFactory.reset( new MyEffectFactory( pd3dDevice ) );

    WCHAR str[MAX_PATH];
    V_RETURN( DXUTFindDXSDKMediaFileCch( str, MAX_PATH, L"Tiny\\tiny.sdkmesh" ) );
    g_FXFactory->SetPath( L"Tiny\\" );
    g_Model = Model::CreateFromSDKMESH( pd3dDevice, str, *g_FXFactory, true );

    UpdateForModel();

    static const XMVECTORF32 s_vecEye = { 0.f, 500.f, -500.f, 0.f };
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

    // Draw 3D object
    XMVECTOR qid = XMQuaternionIdentity();
    const XMVECTORF32 scale = { 1.f, 1.f, 1.f};
    const XMVECTORF32 translate = { 0.f, 0.f, 0.f };
    const XMVECTORF32 rotate = { 0.f, 0.f, 0.f, 1.f };
    XMMATRIX local = XMMatrixMultiply( mWorld, XMMatrixTransformation( g_XMZero, qid, scale, g_XMZero, rotate, translate ) );

    auto pComboBox = g_SampleUI.GetComboBox( IDC_MESH_LIST );
    int meshDraw = -1;
    if ( pComboBox )
    {
        meshDraw = PtrToInt( pComboBox->GetSelectedData() );
    }

    auto pCheckBox = g_SampleUI.GetCheckBox( IDC_WIREFRAME );
    bool wireframe = (pCheckBox) ? pCheckBox->GetChecked() : false;

    if ( g_Model )
    {
        if ( meshDraw == -1 )
        {
            g_Model->Draw( pd3dImmediateContext, *g_States, local, mView, mProj, wireframe );
        }
        else

        {
            int index = 0;
            for( auto it = g_Model->meshes.cbegin(); it != g_Model->meshes.cend(); ++it, ++index )
            {
                if ( index != meshDraw )
                    continue;

                auto mesh = it->get();
                assert( mesh != 0 );

                mesh->PrepareForRendering( pd3dImmediateContext, *g_States, false, wireframe );

                mesh->Draw( pd3dImmediateContext, local, mView, mProj );
            }
        }
    }

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
    g_FXFactory.reset();
    g_Model.reset();
    g_ModelStats.clear();
    g_ModelStats.shrink_to_fit();

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

        case IDC_LOAD_MODEL:
            {
                OPENFILENAME ofn;
                WCHAR szFile[MAX_PATH];
                szFile[0] = 0;
                ZeroMemory( &ofn, sizeof( OPENFILENAME ) );
                ofn.lStructSize = sizeof( OPENFILENAME );
                ofn.lpstrFile = szFile;
                ofn.lpstrFile[0] = 0;
                ofn.nMaxFile = MAX_PATH;
                ofn.lpstrFilter = L"Model supported formats\0*.sdkmesh;*.cmo;*.vbo\0DirectX SDK Mesh\0*.sdkmesh\0Visual Studio Export\0*.cmo\0VBO\0*.vbo\0";
                ofn.nFilterIndex = 1;
                ofn.lpstrInitialDir = NULL;
                ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
                if( GetOpenFileName( &ofn ) )
                {
                    g_FXFactory->SetPath( L"" );

                    WCHAR ext[_MAX_EXT];
                    _wsplitpath_s( szFile, nullptr, 0, nullptr, 0, nullptr, 0, ext, _MAX_EXT );

                    if ( _wcsicmp( ext, L".sdkmesh" ) == 0 )
                    {
                        g_Model = Model::CreateFromSDKMESH( DXUTGetD3D11Device(), szFile, *g_FXFactory, true );
                    }
                    else if ( _wcsicmp( ext, L".vbo" ) == 0 )
                    {
                        g_Model = Model::CreateFromVBO( DXUTGetD3D11Device(), szFile, nullptr, true );
                    }
                    else
                    {
                        g_Model = Model::CreateFromCMO( DXUTGetD3D11Device(), szFile, *g_FXFactory, false );
                    }

                    UpdateForModel();
                    SetViewForModel();
                }
            }
            break;
    }
}
