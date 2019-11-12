/**********************************************************************
*
* LogMessageQueue.h: Declaration of LogMessageQueue
*
* A thread safe LogMessage queue based on std::queue
*
* Comment: This class is intentionally not derived from std::queue to prevent
*   thread unsafe queue access.
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGMESSAGEDEQUE_H_
#define _LOGMESSAGEDEQUE_H_

#include <queue>

#include "LogMessage.h"

class LogMessageQueue
{
public:
  // Constructor
  LogMessageQueue();
  // Destructor
  ~LogMessageQueue();

  // Adds a LogMessage into the queue; thread safe
  void operator+=
    (
    const LogMessage & rLogMessage // Message to add
    );

  // Get the first message and remove it from the queue; thread safe
  LogMessage GetMessage();

private:
  // Not implemented
  LogMessageQueue(const LogMessageQueue & rSrc);
  // Not implemented
  LogMessageQueue & operator=(const LogMessageQueue & rSrc);

  // Was the Critical Section initialized
  bool m_bCriticalSectionInitialized;

  // Critical Section for thread safe operations
  CRITICAL_SECTION m_CriticalSection; 

  // The message queue itself
  std::queue<LogMessage> m_Queue;
};

#endif //_LOGMESSAGEDEQUE_H_