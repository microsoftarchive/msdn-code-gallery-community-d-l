using System;
namespace com.tp.pattern
{
    public interface Pattern
    {
        String DisplayName();
        void ProblemStatement();
        void Help();
        void Process();
        void Implementation();
    }
}
