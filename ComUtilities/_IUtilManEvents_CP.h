#pragma once

template<class T>
class CProxy_IUtilManEvents :
	public IConnectionPointImpl<T, &__uuidof(_IUtilManEvents)>
{
public:
	HRESULT Fire_FileDownloadEx( LONG dlUID,  BSTR sURL,  BSTR sFilename,  BSTR sExt,  BSTR sFileSize,  BSTR sExtraHeaders,  BSTR sRedirURL,  VARIANT_BOOL * SendProgressEvents,  VARIANT_BOOL * bStopDownload,  BSTR * sPathToSave)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[10];
				avarParams[9] = dlUID;
				avarParams[9].vt = VT_I4;
				avarParams[8] = sURL;
				avarParams[8].vt = VT_BSTR;
				avarParams[7] = sFilename;
				avarParams[7].vt = VT_BSTR;
				avarParams[6] = sExt;
				avarParams[6].vt = VT_BSTR;
				avarParams[5] = sFileSize;
				avarParams[5].vt = VT_BSTR;
				avarParams[4] = sExtraHeaders;
				avarParams[4].vt = VT_BSTR;
				avarParams[3] = sRedirURL;
				avarParams[3].vt = VT_BSTR;
				avarParams[2].byref = SendProgressEvents;
				avarParams[2].vt = VT_BOOL|VT_BYREF;
				avarParams[1].byref = bStopDownload;
				avarParams[1].vt = VT_BOOL|VT_BYREF;
				avarParams[0].byref = sPathToSave;
				avarParams[0].vt = VT_BSTR|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 10, 0 };
				hr = pConnection->Invoke(1, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLProgress( LONG dlUID,  BSTR sURL,  LONG lProgress,  LONG lProgressMax,  VARIANT_BOOL * CancelDl)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[5];
				avarParams[4] = dlUID;
				avarParams[4].vt = VT_I4;
				avarParams[3] = sURL;
				avarParams[3].vt = VT_BSTR;
				avarParams[2] = lProgress;
				avarParams[2].vt = VT_I4;
				avarParams[1] = lProgressMax;
				avarParams[1].vt = VT_I4;
				avarParams[0].byref = CancelDl;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 5, 0 };
				hr = pConnection->Invoke(2, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLEndDownload( LONG dlUID,  BSTR sURL,  BSTR sSavedFilePath)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[3];
				avarParams[2] = dlUID;
				avarParams[2].vt = VT_I4;
				avarParams[1] = sURL;
				avarParams[1].vt = VT_BSTR;
				avarParams[0] = sSavedFilePath;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 3, 0 };
				hr = pConnection->Invoke(3, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLDownloadError( LONG dlUID,  BSTR sURL,  BSTR sErrorMsg)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[3];
				avarParams[2] = dlUID;
				avarParams[2].vt = VT_I4;
				avarParams[1] = sURL;
				avarParams[1].vt = VT_BSTR;
				avarParams[0] = sErrorMsg;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 3, 0 };
				hr = pConnection->Invoke(4, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLAuthenticate( LONG dlUID,  BSTR * sUsername,  BSTR * sPassword,  VARIANT_BOOL * Cancel)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[4];
				avarParams[3] = dlUID;
				avarParams[3].vt = VT_I4;
				avarParams[2].byref = sUsername;
				avarParams[2].vt = VT_BSTR|VT_BYREF;
				avarParams[1].byref = sPassword;
				avarParams[1].vt = VT_BSTR|VT_BYREF;
				avarParams[0].byref = Cancel;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 4, 0 };
				hr = pConnection->Invoke(5, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLBeginningTransaction( LONG dlUID,  BSTR sURL,  BSTR sRequestHeaders,  BSTR * sAdditionalRequestHeaders,  VARIANT_BOOL * bResuming,  VARIANT_BOOL * bCancel)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[6];
				avarParams[5] = dlUID;
				avarParams[5].vt = VT_I4;
				avarParams[4] = sURL;
				avarParams[4].vt = VT_BSTR;
				avarParams[3] = sRequestHeaders;
				avarParams[3].vt = VT_BSTR;
				avarParams[2].byref = sAdditionalRequestHeaders;
				avarParams[2].vt = VT_BSTR|VT_BYREF;
				avarParams[1].byref = bResuming;
				avarParams[1].vt = VT_BOOL|VT_BYREF;
				avarParams[0].byref = bCancel;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 6, 0 };
				hr = pConnection->Invoke(8, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLResponse( LONG dlUID,  BSTR sURL,  LONG lResponseCode,  BSTR sResponseHeaders,  VARIANT_BOOL * CancelDl)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[5];
				avarParams[4] = dlUID;
				avarParams[4].vt = VT_I4;
				avarParams[3] = sURL;
				avarParams[3].vt = VT_BSTR;
				avarParams[2] = lResponseCode;
				avarParams[2].vt = VT_I4;
				avarParams[1] = sResponseHeaders;
				avarParams[1].vt = VT_BSTR;
				avarParams[0].byref = CancelDl;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 5, 0 };
				hr = pConnection->Invoke(9, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnStartManagedAPP( BSTR URL, BSTR RequestHeaders, BSTR PostData, BSTR PostDataMime, IDispatch * pDispCustPassThruSink, VARIANT_BOOL bNeedFileName, BSTR * sLocalFileName, VARIANT_BOOL * bClientHandled, VARIANT_BOOL bAsynchDownload, VARIANT_BOOL * bCancelDownload)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[10];
				avarParams[9] = URL;
				avarParams[9].vt = VT_BSTR;
				avarParams[8] = RequestHeaders;
				avarParams[8].vt = VT_BSTR;
				avarParams[7] = PostData;
				avarParams[7].vt = VT_BSTR;
				avarParams[6] = PostDataMime;
				avarParams[6].vt = VT_BSTR;
				avarParams[5] = pDispCustPassThruSink;
				avarParams[5].vt = VT_DISPATCH;
				avarParams[4] = bNeedFileName;
				avarParams[4].vt = VT_BOOL;
				avarParams[3].byref = sLocalFileName;
				avarParams[3].vt = VT_BSTR|VT_BYREF;
				avarParams[2].byref = bClientHandled;
				avarParams[2].vt = VT_BOOL|VT_BYREF;
				avarParams[1] = bAsynchDownload;
				avarParams[1].vt = VT_BOOL;
				avarParams[0].byref = bCancelDownload;
				avarParams[0].vt = VT_BOOL|VT_BYREF;

				DISPPARAMS params = { avarParams, NULL, 10, 0 };
				hr = pConnection->Invoke(10, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnStartCustManagedApp( BSTR URL, IDispatch * pDispCustManagedApp)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[2];
				avarParams[1] = URL;
				avarParams[1].vt = VT_BSTR;
				avarParams[0] = pDispCustManagedApp;
				avarParams[0].vt = VT_DISPATCH;
				DISPPARAMS params = { avarParams, NULL, 2, 0 };
				hr = pConnection->Invoke(11, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_OnFileDLFileFullyWritten(LONG dlUID, BSTR sURL, BSTR sSavedFilePath)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[3];
				avarParams[2] = dlUID;
				avarParams[2].vt = VT_I4;
				avarParams[1] = sURL;
				avarParams[1].vt = VT_BSTR;
				avarParams[0] = sSavedFilePath;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 3, 0 };
				hr = pConnection->Invoke(12, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_ManagedAppBeginningTransaction(BSTR sURL,  BSTR sRequestHeaders,  BSTR * sAdditionalHeaders,  VARIANT_BOOL * Cancel)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[4];
				avarParams[3] = sURL;
				avarParams[3].vt = VT_BSTR;
				avarParams[2] = sRequestHeaders;
				avarParams[2].vt = VT_BSTR;
				avarParams[1].byref = sAdditionalHeaders;
				avarParams[1].vt = VT_BSTR|VT_BYREF;
				avarParams[0].byref = Cancel;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 4, 0 };
				hr = pConnection->Invoke(13, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_ManagedAppOnResponse(BSTR sURL,  BSTR sResponseHeaders,  BSTR sRedirectedUrl,  BSTR sRedirectHeaders,  VARIANT_BOOL * Cancel)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[5];
				avarParams[4] = sURL;
				avarParams[4].vt = VT_BSTR;
				avarParams[3] = sResponseHeaders;
				avarParams[3].vt = VT_BSTR;
				avarParams[2] = sRedirectedUrl;
				avarParams[2].vt = VT_BSTR;
				avarParams[1] = sRedirectHeaders;
				avarParams[1].vt = VT_BSTR;
				avarParams[0].byref = Cancel;
				avarParams[0].vt = VT_BOOL|VT_BYREF;
				DISPPARAMS params = { avarParams, NULL, 5, 0 };
				hr = pConnection->Invoke(14, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_ManagedAppDataFullyRead(BSTR sURL)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[1];
				avarParams[0] = sURL;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 1, 0 };
				hr = pConnection->Invoke(16, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_ManagedAppDataFullyAvailable(BSTR sURL)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[1];
				avarParams[0] = sURL;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 1, 0 };
				hr = pConnection->Invoke(17, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
	HRESULT Fire_ManagedAppOperationFailed(BSTR sURL)
	{
		HRESULT hr = S_OK;
		T * pThis = static_cast<T *>(this);
		int cConnections = m_vec.GetSize();

		for (int iConnection = 0; iConnection < cConnections; iConnection++)
		{
			pThis->Lock();
			CComPtr<IUnknown> punkConnection = m_vec.GetAt(iConnection);
			pThis->Unlock();

			IDispatch * pConnection = static_cast<IDispatch *>(punkConnection.p);

			if (pConnection)
			{
				CComVariant avarParams[1];
				avarParams[0] = sURL;
				avarParams[0].vt = VT_BSTR;
				DISPPARAMS params = { avarParams, NULL, 1, 0 };
				hr = pConnection->Invoke(18, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &params, NULL, NULL, NULL);
			}
		}
		return hr;
	}
};

