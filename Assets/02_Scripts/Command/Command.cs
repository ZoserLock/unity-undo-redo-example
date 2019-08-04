using System.Collections;
using System.Collections.Generic;

public interface Command
{
    string GetName();
    void Execute();
    void Unexecute();
}
