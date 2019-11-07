// Testv2.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

//
// IMAPI V2 インターフェースを利用したサンプル例
// スマートポインター編

// IMAPI V2 インターフェース
_COM_SMARTPTR_TYPEDEF( IDiscMaster2 , __uuidof(IDiscMaster2) );
_COM_SMARTPTR_TYPEDEF( IDiscRecorder2 , __uuidof(IDiscRecorder2) );
_COM_SMARTPTR_TYPEDEF( IFileSystemImage , __uuidof(IFileSystemImage) );
_COM_SMARTPTR_TYPEDEF( IFsiDirectoryItem , __uuidof(IFsiDirectoryItem) );
_COM_SMARTPTR_TYPEDEF( IFileSystemImageResult , __uuidof(IFileSystemImageResult) );
_COM_SMARTPTR_TYPEDEF( IDiscFormat2Data , __uuidof(IDiscFormat2Data) );


BSTR g_appName = ::SysAllocString(L"IMAPIv2 TEST");

// デスクへの書き込み
void WriteToDisc(LPCWSTR folder)
{
    HRESULT hr;
    IDiscMaster2Ptr DiscMaster2 = NULL;
    IDiscRecorder2Ptr DiscRecorder2 = NULL;
    IDiscFormat2DataPtr DiscFormat2Data = NULL;
	BSTR path =  ::SysAllocString(folder);

	// DiscMaster2インスタンスの作成
    hr = DiscMaster2.CreateInstance( CLSID_MsftDiscMaster2 );
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	// DiscRecorder2インスタンスの作成
    hr = DiscRecorder2.CreateInstance( CLSID_MsftDiscRecorder2 );
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	// IDiscFormat2Dataインスタンスの作成
    hr = DiscFormat2Data.CreateInstance( CLSID_MsftDiscFormat2Data );
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	//
    // レコーダーの選択
	//
	BSTR uniqueId;

	hr = DiscMaster2->get_Item(0, &uniqueId);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = DiscRecorder2->InitializeDiscRecorder( uniqueId );
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = DiscFormat2Data->put_Recorder(DiscRecorder2);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}


	//
	// HDD上のフォルダから 構造化ストレージを作成
	//
    IFileSystemImagePtr FileSystemImage = NULL;
	IFsiDirectoryItemPtr root = NULL;
	IFileSystemImageResultPtr result = NULL;
	IStreamPtr stream = NULL;
	
	hr = FileSystemImage.CreateInstance( CLSID_MsftFileSystemImage );
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = FileSystemImage->put_FileSystemsToCreate( FsiFileSystemUDF ); // UDF を作成
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

		hr = FileSystemImage->ChooseImageDefaultsForMediaType( IMAPI_MEDIA_TYPE_DVDDASHRW ); // DVD-RW
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = FileSystemImage->get_Root(&root);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = root->AddTree(path, VARIANT_FALSE);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = FileSystemImage->CreateResultImage(&result);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = result->get_ImageStream(&stream);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	//
	// 属性の設定
	//
	hr = DiscFormat2Data->put_ForceMediaToBeClosed(VARIANT_TRUE);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	hr = DiscFormat2Data->put_ClientName(g_appName);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}


	//
    // 書き込み開始
	//
    wprintf_s(L"メディアに書き込み\n");
	hr = DiscFormat2Data->Write(stream);
    if ( !SUCCEEDED(hr) )
	{
		wprintf_s(L"Error (0x%x) (%d)\n", hr, __LINE__);
		return;
	}

	wprintf_s(L"書き込み終了\n");


	return;
}

// メイン処理
// 引数：書き込むフォルダ
int _tmain(int argc, _TCHAR* argv[])
{
    HRESULT hr;

    _wsetlocale( LC_ALL, L"jpn" );

	if ( argc != 2 )
	{
		wprintf_s(L"引数：書き込むフォルダのフルパス\n");
		return 1;
	}

    // COMの初期化
    hr = ::CoInitialize(NULL);
	
	// 書き込み
	WriteToDisc(argv[1]);
	
	// COMの終了
    ::CoUninitialize();

	return 0;
}

