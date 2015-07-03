using System;

namespace Contracts
{
    // this interface defines the data that will be imported 
    // along with the interface
    // keep in mind that the name MUST be suffixed with 'Data'
    // by convention:
    // IOperation -- > IOperationData
    // in a real life project this interface definition would 
    // probably be defined in a separate project so that both 
    // exporter and importer can reference it
    public interface IOperationData
    {
        Char Symbol { get; }

        String OperationName { get; }
    }
}