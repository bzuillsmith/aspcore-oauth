using System;

namespace AspCoreExperiments.Models
{
    public class Part
    {
        public Guid Id {get;set;}
        public string PartNumber {get;set;}
        public string Description {get;set;}
        public UnitType UnitType {get;set;}
        public double Units {get;set;}
        public string Type {get;set;}
    }

    ///<summary>
    /// The unit type of a part determines how the part is processed by the program
    ///</summary>
    public enum UnitType {
        Count = 0,
        NonOptimizedLength = 1,
        OptimizedLenth = 2
    }
}