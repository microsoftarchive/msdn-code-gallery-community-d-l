/**********************************************************************
*
* LogDistributor.h: Declaration of LogDistributor
*
* The log message distributor
*
* Comment: This class is implemented as a singleton
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGDISTRIBUTOR_H_
#define _LOGDISTRIBUTOR_H_

#include <vector>

#include "LogMessage.h"
#include "LogObserver.h"

class LogDistributor
{
public:
  // Returns the reference to the one and only distributor
  static LogDistributor & Instance();

  // Destructor
  ~LogDistributor();

  // Adds an observer to the list and starts it
  void operator+=
    (
    LogObserver * pObserver // Observer to add
    );

  // Removes an observer from the list, stops it, and frees its allocated memory
  void operator-=
    (
    const LogObserver * pObserver // Observer to remove
    );

  // Tells each observer to which the message belongs to create a log entry
  void Log
    (
    const LogMessage & rMessage // Message to log
    );

  // Returns the number of active observers
  int GetNumberOfObservers() const
  { return (m_vecObserver.size()); }

  // Returns an observer by index
  const LogObserver * GetObserver
    (
    const int nObserver // The index of the observer to return
    )
  { return (m_vecObserver[nObserver]); }

private:
  typedef std::vector<LogObserver * > ObserverVector;
  typedef std::vector<LogObserver * >::iterator itObserverVector;

  // Functor to tell an observer to which the message belongs to create a log entry
  struct CreateLogEntry 
    : public std::binary_function<LogObserver *, LogMessage, bool> // bool is needed to make bind2nd happy
  {
    bool operator() (LogObserver * pLogObserver, const LogMessage & rMessage) const
    {
      if (pLogObserver->GetArea() & rMessage.GetArea() // Does the area match?
        && pLogObserver->GetLevel() >= rMessage.GetLevel())  // Does the level match
      { 
        // Do not write synchronously, just add the message to the queue and increase the semaphore
        pLogObserver->AddMessage(rMessage); 
        ::ReleaseSemaphore(pLogObserver->GetSemaphoreHandle(), 1L, NULL);
        return (true); 
      }
      return (false);
    }
  };

  // Constructor
  LogDistributor();

  // Not implemented
  LogDistributor(const LogDistributor & rSrc);
  // Not implemented
  LogDistributor & operator=(const LogDistributor & rSrc);

  // Vector of all active observer
  ObserverVector m_vecObserver;

  // Is the critical section initialized
  bool m_bCriticalSectionInitialized;

  // Critical Section to synchronize shared data access
  CRITICAL_SECTION m_CriticalSection; 
};

#endif // _LOGDISTRIBUTOR_H_