/**********************************************************************
*
* LogMessage.h: Definition of LogMessage
*
* The LogMessage
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGMESSAGE_H_
#define _LOGMESSAGE_H_

#include <string>

class LogMessage
{
public:
  enum Area  { evGUI=1, evCom=2, evUserActivity=4 };
  enum Level { evError, evEvent, evTrace, evDebug };

  // Constructor
  LogMessage
    (
    const Area nArea,   // The message area
    const Level nLevel, // The message level
    char * pszText     // The message text
    ) 
    : m_nArea(nArea), m_nLevel(nLevel), m_strText(pszText) 
  { }

  // Copy ctor
  LogMessage
    (
    const LogMessage & rSrc // The message to copy
    )
    : m_nArea(rSrc.m_nArea), m_nLevel(rSrc.m_nLevel), m_strText(rSrc.m_strText) 
  { }


  // Returns the message text
  std::string GetText() const { return (m_strText); }

  // Returns the message area
  Area GetArea() const { return (m_nArea); }

  // Returns the message level
  Level GetLevel() const { return(m_nLevel); }

private:
  // Not implemented
  LogMessage & operator=(const LogMessage & rSrc);

  // The text
  const std::string m_strText;

  // The area
  const Area m_nArea;

  // The level
  const Level m_nLevel;
};

#endif // _LOGMESSAGE_H_