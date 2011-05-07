#pragma once

class CCriticalSectionWrapper : CRITICAL_SECTION {
public:
	CCriticalSectionWrapper(){
		::InitializeCriticalSection(this);
	}

	~CCriticalSectionWrapper(){
		::DeleteCriticalSection(this);
	}
	
	void lock(){
		EnterCriticalSection(this);
	}

	void unlock(){
		LeaveCriticalSection(this);
	}

};