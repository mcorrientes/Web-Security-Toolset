#pragma once

class CTmpBuffer
{
	#define STARTUP_TEMP_BUFFER MAX_PATH
	#define RES_BUFFER_SIZE 512
	#ifdef _UNICODE
		#define CHAR_FUDGE 1    // one TCHAR unused is good enough
	#else
		#define CHAR_FUDGE 2    // two BYTES unused for case of DBC last char
	#endif
public:
	CTmpBuffer(void);
	CTmpBuffer(LPCTSTR strText);
	CTmpBuffer(UINT iSize);
	~CTmpBuffer(void);
	
	// *** Local ***

	//We don't destroy the buffer
	//Usefull in loops when reading values into the buffer
	//using = operator.
	void ResetBuffer();
//Allocate buffer
	UINT AllocateBuffer(UINT nsize);
//Append a string
	UINT Append(LPCTSTR strText, UINT iMaxLen = 0);
//Append a BSTR
	UINT AppendBSTR(BSTR strText, UINT iMaxLen = 0);
//Append an int value
	UINT Appendint(int iNumber, int radix = 10);
//Append a long value
	UINT Appendlong(long lNumber, int radix = 10);
//Append resource string
	UINT AppendResStr(UINT nID, UINT iMaxLen = 0);
//Append GUID
	UINT AppendGUID(REFGUID src);

//Accessors
	TCHAR* GetString(void);
	UINT ReleaseString(void);
	LPCTSTR GetBuffer(void) const;
	//Get buffer len, may or may not contain any characters
	UINT GetBufferLen(void) const;
	//Get the Text len (number of actual chars)
	UINT GetBufferTextLen(void) const;
	TCHAR GetAt(int nIndex);
	void SetAt(int nIndex, TCHAR ch);

//Operators
	TCHAR* operator &() { return m_Buffer; }
	operator LPCTSTR() const { return m_Buffer; }
	TCHAR operator[] (int nIndex);

	CTmpBuffer& operator=(const CTmpBuffer& src);
	CTmpBuffer& operator=(const LPCTSTR src);
	CTmpBuffer& operator+=(const CTmpBuffer& strSrc);
	CTmpBuffer& operator+=(const LPCTSTR strSrc);
	CTmpBuffer& operator=(const UINT nID);
	CTmpBuffer& operator+=(const UINT nID);

private:
	ULONG		m_cRef;
	LPTSTR		m_Buffer;
	UINT		m_BufferLen;
	//where to write
	UINT		m_BufferTextLen;
	bool		m_Allocated;
	HINSTANCE	m_hInst;
	
	void InitLocalResources();
	void ClearLocalResources();
};
