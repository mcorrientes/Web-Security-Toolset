#include "StdAfx.h"
#include "TmpBuffer.h"

CTmpBuffer::CTmpBuffer(void)
{
	InitLocalResources();
	AllocateBuffer(STARTUP_TEMP_BUFFER);
}

CTmpBuffer::CTmpBuffer(LPCTSTR strText)
{
	InitLocalResources();
	Append(strText);
}

CTmpBuffer::CTmpBuffer(UINT iSize)
{
	InitLocalResources();
	AllocateBuffer(iSize);
}

CTmpBuffer::~CTmpBuffer(void)
{
	ClearLocalResources();
}

void CTmpBuffer::ResetBuffer()
{
	if( (m_Buffer) && (m_BufferLen > 0) && (m_Allocated == true) )
	{
		//Mark the beginning and end
		m_Buffer[m_BufferLen] = _T('\0');
		m_Buffer[0] = _T('\0');
	}
	m_BufferTextLen = 0;
}

//Allocate buffer
UINT CTmpBuffer::AllocateBuffer(UINT nsize)
{
	if(nsize < 1)
		return 0;
	//Attempting to increase storage
	if( (m_Buffer) && (m_Allocated == true) )
	{
		LPTSTR tempbuffer = (LPTSTR)malloc((m_BufferLen+nsize+1) * sizeof(TCHAR));
		if(tempbuffer == NULL)
			return -1;
		//Adjust actual size of buffer
		m_BufferLen += nsize;
		tempbuffer[m_BufferLen] = _T('\0');
		//Copy what we have (m_BufferTextLen = actual number of characters in the buffer)
		if(m_BufferTextLen > 0)
			memcpy(tempbuffer, m_Buffer, m_BufferTextLen * sizeof(TCHAR));

		tempbuffer[m_BufferTextLen] = _T('\0');
		//Free current buffer and reassign
		free(m_Buffer);
		m_Buffer = tempbuffer;
	}
	else
	{
		//First time, just allocate
		m_Buffer = (LPTSTR)malloc( (nsize+1) * sizeof(TCHAR));
		if(m_Buffer == NULL)
			return -1;
		m_BufferLen = nsize;

		m_Buffer[m_BufferLen] = _T('\0');
		m_Buffer[0] = _T('\0');

		//No text in the buffer
		m_BufferTextLen = 0;
	}
	m_Allocated = true;
	return m_BufferLen;
}

//Append a string
UINT CTmpBuffer::Append(LPCTSTR strText, UINT iMaxLen)
{
	if( (strText == NULL) || (*strText == _T('\0')) )
		return 0;

	UINT nappend = 0;
	if(iMaxLen > 0)
		nappend = iMaxLen;
	else
		nappend = (UINT)_tcslen(strText);

	if(nappend == 0)
		return 0;

	//Get actual buffer len + len of new text
	//to compare with the total buffer len
	UINT newlen = m_BufferTextLen + nappend;

	//Check
	if( (m_Buffer == NULL) || (m_Allocated == false) )
	{
		AllocateBuffer(newlen);
	}

	//Still have room
	if(m_BufferLen >= newlen)
	{
		//Just copy data
		memcpy(m_Buffer+m_BufferTextLen, strText, nappend * sizeof(TCHAR));
	}
	else
	{
		//Create a new storage + nGrowSize for the next strText
		LPTSTR tempbuffer = (LPTSTR)malloc( (newlen+1) * sizeof(TCHAR));
		if(tempbuffer == NULL)
			return 0;
		m_BufferLen = newlen;
		tempbuffer[m_BufferLen] = _T('\0');
		//Copy from buffer first and then the actual data
		memcpy(tempbuffer, m_Buffer, m_BufferTextLen * sizeof(TCHAR));
		memcpy(tempbuffer+m_BufferTextLen, strText, nappend * sizeof(TCHAR));
		//Empty buffer and reassign
		free(m_Buffer);
		m_Buffer = tempbuffer;
	}
	//Adjust actual number of text in buffer
	m_BufferTextLen = newlen;
	//Mark the end of actual text appended
	m_Buffer[m_BufferTextLen] = _T('\0');
	return newlen;
}

//Append a BSTR
UINT CTmpBuffer::AppendBSTR(BSTR strText, UINT iMaxLen)
{
	if(strText == NULL)
		return 0;
	UINT dwChars = ::SysStringLen(strText);
	LPTSTR pLocal = (LPTSTR)malloc( (dwChars+1) * sizeof(TCHAR));
	if(pLocal == NULL)
		return 0;
	pLocal[dwChars] = _T('\0');
#ifdef UNICODE
	lstrcpyn(pLocal, strText, dwChars);
#else
	WideCharToMultiByte(CP_ACP, 0, strText, -1, pLocal, dwChars, NULL, NULL);
#endif
	
	UINT iRet = Append(pLocal, iMaxLen);
	free(pLocal);
	return iRet;
}

//Append an int value
UINT CTmpBuffer::Appendint(int iNumber, int radix)
{
	TCHAR tmp[50];
#ifdef UNICODE
	_itow(iNumber, tmp, radix);
#else
	_itoa(iNumber, tmp, radix);
#endif
	return Append(tmp);
}

//Append a long value
UINT CTmpBuffer::Appendlong(long lNumber, int radix)
{
	TCHAR tmp[50];
#ifdef UNICODE
	_ltow(lNumber, tmp, radix);
#else
	_ltoa(lNumber, tmp, radix);
#endif
	return Append(tmp);
}

UINT CTmpBuffer::AppendGUID(REFGUID src)
{
	OLECHAR wszBuff[39];
	int i = StringFromGUID2(src, wszBuff, 39);
	TCHAR szBuff[39];
#ifdef UNICODE
	lstrcpyn(szBuff, wszBuff, 39);
#else
	WideCharToMultiByte(CP_ACP, 0, wszBuff, -1, szBuff, 39, NULL, NULL);
#endif
	return Append((LPCTSTR)szBuff);
}

UINT CTmpBuffer::AppendResStr(UINT nID, UINT iMaxLen)
{
	TCHAR sz[RES_BUFFER_SIZE];
	int nCount =  sizeof(sz) / sizeof(sz[0]);
//	UINT nLen = ::LoadString(m_hInst, nID, sz, sizeof(sz)/sizeof(TCHAR));
	UINT nLen = ::LoadString(m_hInst, nID, sz, nCount);
	UINT iRet = 0;
	if(nLen == 0)
		return iRet;
	//All string was read else need to read entire string
	//by increasing buffer size and trying again.
	//if (nCount - nLen > CHAR_FUDGE)
	iRet = Append( (LPCTSTR)sz, iMaxLen );
	return iRet;
}

//Accessors
TCHAR* CTmpBuffer::GetString(void)
{ return m_Buffer; }

UINT CTmpBuffer::ReleaseString(void)
{
	UINT iRet = 0;
	if(m_Buffer)
	{
		iRet = (UINT)_tcslen(m_Buffer);
		if (iRet > 0)
		{
			m_BufferLen = iRet;
			m_BufferTextLen = iRet;
			m_Buffer[m_BufferTextLen] = _T('\0');
		}
	}
	return iRet;
}

LPCTSTR CTmpBuffer::GetBuffer(void) const
{ return m_Buffer; }

UINT CTmpBuffer::GetBufferLen(void) const
{ return m_BufferLen; }

UINT CTmpBuffer::GetBufferTextLen(void) const
{ return m_BufferTextLen; }

TCHAR CTmpBuffer::GetAt(int nIndex)
{
	if((UINT)nIndex < m_BufferLen) 
		return m_Buffer[nIndex];
	else
		return 0;
}
void CTmpBuffer::SetAt(int nIndex, TCHAR ch)
{
	if((UINT)nIndex < m_BufferLen)
		m_Buffer[nIndex] = ch;
}

TCHAR CTmpBuffer::operator[] (int nIndex)
{
	if((UINT)nIndex < m_BufferLen) 
		return m_Buffer[nIndex];
	else
		return 0;
}

CTmpBuffer& CTmpBuffer::operator=(const CTmpBuffer& src)
{
	//We don't destroy any buffers allocated
	ResetBuffer();
	Append(src);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator=(const LPCTSTR src)
{
	ResetBuffer();
	Append(src);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const CTmpBuffer& strSrc)
{
	Append(strSrc);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const LPCTSTR strSrc)
{
	Append(strSrc);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator=(const UINT nID)
{
	ResetBuffer();
	AppendResStr(nID);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const UINT nID)
{
	AppendResStr(nID);
	return *this;
}

void CTmpBuffer::InitLocalResources()
{
	m_cRef = 1;
	m_Buffer = NULL;
	m_BufferLen = 0;
	m_BufferTextLen = 0;
	m_Allocated = false;
	#if (_ATL_VER >= 0x0700)
		m_hInst = ATL::_AtlBaseModule.GetResourceInstance();
	#else //#if (_ATL_VER == 0x0300)
		m_hInst = _Module.GetResourceInstance();
	#endif
}

void CTmpBuffer::ClearLocalResources()
{
	if( (m_Buffer) && (m_BufferLen > 0) && (m_Allocated == true) )
		free(m_Buffer);
	m_Buffer = NULL;
	m_BufferLen = 0;
	m_BufferTextLen = 0;
	m_Allocated = false;
}

