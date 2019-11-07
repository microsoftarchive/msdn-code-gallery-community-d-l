/**********************************************************************
*
* ConsoleObserver.h: Definition of ConsoleObserver
*
* Observer which generates console output
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _CONSOLEOBSERVER_H_
#define _CONSOLEOBSERVER_H_

#include <stdio.h>

#include "LogObserver.h"
#include "LogMessage.h"

class ConsoleObserver : public LogObserver
{
public:
  // Constructor
  ConsoleObserver
    (
    const int iArea,                // Area(s) to observe
    const LogMessage::Level nLevel  // Level to observe
    )
    : LogObserver(iArea, nLevel, Console)
  { }

protected:
  // Writes the Log-Message
  virtual void Write(const LogMessage & rMessage)
  { printf("ConsoleObserver (%ld): %s\n", ::GetCurrentThreadId(),
           rMessage.GetText().c_str()); }

private:
  // Not implemented
  ConsoleObserver(const ConsoleObserver & rSrc);
  // Not implemented
  ConsoleObserver & operator=(const ConsoleObserver & rSrc);
};

#endif // _CONSOLEOBSERVER_H_