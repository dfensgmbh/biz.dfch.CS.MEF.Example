/**
 * Operation interface definition
 **/
using System;

namespace Contracts
{
    // this interface defines how to import and export extensions
    // in a real life project this interface definition would 
    // probably be defined in a separate project so that both 
    // exporter and importer can reference it
    public interface IOperation
    {
        int Operate(int left, int right);
    }
}