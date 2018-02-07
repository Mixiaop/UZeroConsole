﻿namespace UZeroConsole.Monitoring.SQL.QueryPlans
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan", IsNullable = false)]
    public partial class ShowPlanXML
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Batch", IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Statements", IsNullable = false, NestingLevel = 1)]
        public StmtBlockType[][] BatchSequence;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Build;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ClusteredMode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ClusteredModeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtBlockType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StmtCond", typeof(StmtCondType))]
        [System.Xml.Serialization.XmlElementAttribute("StmtCursor", typeof(StmtCursorType))]
        [System.Xml.Serialization.XmlElementAttribute("StmtReceive", typeof(StmtReceiveType))]
        [System.Xml.Serialization.XmlElementAttribute("StmtSimple", typeof(StmtSimpleType))]
        [System.Xml.Serialization.XmlElementAttribute("StmtUseDb", typeof(StmtUseDbType))]
        public BaseStmtInfoType[] Items;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtCondType : BaseStmtInfoType
    {

        /// <remarks/>
        public StmtCondTypeCondition Condition;

        /// <remarks/>
        public StmtCondTypeThen Then;

        /// <remarks/>
        public StmtCondTypeElse Else;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtCondTypeCondition
    {

        /// <remarks/>
        public QueryPlanType QueryPlan;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UDF")]
        public FunctionType[] UDF;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class QueryPlanType
    {

        /// <remarks/>
        public InternalInfoType InternalInfo;

        /// <remarks/>
        public ThreadStatType ThreadStat;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("MissingIndexGroup", IsNullable = false)]
        public MissingIndexGroupType[] MissingIndexes;

        /// <remarks/>
        public GuessedSelectivityType GuessedSelectivity;

        /// <remarks/>
        public UnmatchedIndexesType UnmatchedIndexes;

        /// <remarks/>
        public WarningsType Warnings;

        /// <remarks/>
        public MemoryGrantType MemoryGrantInfo;

        /// <remarks/>
        public OptimizerHardwareDependentPropertiesType OptimizerHardwareDependentProperties;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] ParameterList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DegreeOfParallelism;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DegreeOfParallelismSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int EffectiveDegreeOfParallelism;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDegreeOfParallelismSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NonParallelPlanReason;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong MemoryGrant;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MemoryGrantSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong CachedPlanSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CachedPlanSizeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong CompileTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CompileTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong CompileCPU;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CompileCPUSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong CompileMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CompileMemorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool UsePlan;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UsePlanSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class InternalInfoType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CursorPlanType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Operation")]
        public CursorPlanTypeOperation[] Operation;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CursorName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CursorType CursorActualType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CursorActualTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CursorType CursorRequestedType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CursorRequestedTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CursorPlanTypeCursorConcurrency CursorConcurrency;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CursorConcurrencySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForwardOnly;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForwardOnlySpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CursorPlanTypeOperation
    {

        /// <remarks/>
        public QueryPlanType QueryPlan;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UDF")]
        public FunctionType[] UDF;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CursorPlanTypeOperationOperationType OperationType;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class FunctionType
    {

        /// <remarks/>
        public StmtBlockType Statements;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProcName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsNativelyCompiled;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsNativelyCompiledSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum CursorPlanTypeOperationOperationType
    {

        /// <remarks/>
        FetchQuery,

        /// <remarks/>
        PopulateQuery,

        /// <remarks/>
        RefreshQuery,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum CursorType
    {

        /// <remarks/>
        Dynamic,

        /// <remarks/>
        FastForward,

        /// <remarks/>
        Keyset,

        /// <remarks/>
        SnapShot,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum CursorPlanTypeCursorConcurrency
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Read Only")]
        ReadOnly,

        /// <remarks/>
        Pessimistic,

        /// <remarks/>
        Optimistic,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class OptimizerHardwareDependentPropertiesType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong EstimatedAvailableMemoryGrant;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong EstimatedPagesCached;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong EstimatedAvailableDegreeOfParallelism;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstimatedAvailableDegreeOfParallelismSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MemoryGrantType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong SerialRequiredMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong SerialDesiredMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong RequiredMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequiredMemorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong DesiredMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DesiredMemorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong RequestedMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RequestedMemorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong GrantWaitTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GrantWaitTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong GrantedMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GrantedMemorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong MaxUsedMemory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxUsedMemorySpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class HashSpillDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong GrantedMemoryKb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GrantedMemoryKbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong UsedMemoryKb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UsedMemoryKbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong WritesToTempDb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WritesToTempDbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ReadsFromTempDb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReadsFromTempDbSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SortSpillDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong GrantedMemoryKb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GrantedMemoryKbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong UsedMemoryKb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UsedMemoryKbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong WritesToTempDb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WritesToTempDbSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ReadsFromTempDb;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReadsFromTempDbSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class AffectingConvertWarningType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AffectingConvertWarningTypeConvertIssue ConvertIssue;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Expression;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum AffectingConvertWarningTypeConvertIssue
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Cardinality Estimate")]
        CardinalityEstimate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Seek Plan")]
        SeekPlan,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class WaitWarningType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public WaitWarningTypeWaitType WaitType;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong WaitTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WaitTimeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum WaitWarningTypeWaitType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Memory Grant")]
        MemoryGrant,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SpillToTempDbType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong SpillLevel;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpillLevelSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong SpilledThreadCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpilledThreadCountSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "ColumnReferenceListType", Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ColumnReferenceListType1
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnReference")]
        public ColumnReferenceType[] ColumnReference;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ColumnReferenceType
    {

        /// <remarks/>
        public ScalarType ScalarOperator;

        /// <remarks/>
        public InternalInfoType InternalInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Server;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Database;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Schema;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Table;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Alias;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Column;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ComputedColumn;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComputedColumnSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterCompiledValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterRuntimeValue;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScalarType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Aggregate", typeof(AggregateType))]
        [System.Xml.Serialization.XmlElementAttribute("Arithmetic", typeof(ArithmeticType))]
        [System.Xml.Serialization.XmlElementAttribute("Assign", typeof(AssignType))]
        [System.Xml.Serialization.XmlElementAttribute("Compare", typeof(CompareType))]
        [System.Xml.Serialization.XmlElementAttribute("Const", typeof(ConstType))]
        [System.Xml.Serialization.XmlElementAttribute("Convert", typeof(ConvertType))]
        [System.Xml.Serialization.XmlElementAttribute("IF", typeof(ConditionalType))]
        [System.Xml.Serialization.XmlElementAttribute("Identifier", typeof(IdentType))]
        [System.Xml.Serialization.XmlElementAttribute("Intrinsic", typeof(IntrinsicType))]
        [System.Xml.Serialization.XmlElementAttribute("Logical", typeof(LogicalType))]
        [System.Xml.Serialization.XmlElementAttribute("MultipleAssign", typeof(MultAssignType))]
        [System.Xml.Serialization.XmlElementAttribute("ScalarExpressionList", typeof(ScalarExpressionListType))]
        [System.Xml.Serialization.XmlElementAttribute("Sequence", typeof(ScalarSequenceType))]
        [System.Xml.Serialization.XmlElementAttribute("Subquery", typeof(SubqueryType))]
        [System.Xml.Serialization.XmlElementAttribute("UDTMethod", typeof(UDTMethodType))]
        [System.Xml.Serialization.XmlElementAttribute("UserDefinedAggregate", typeof(UDAggregateType))]
        [System.Xml.Serialization.XmlElementAttribute("UserDefinedFunction", typeof(UDFType))]
        public object Item;

        /// <remarks/>
        public InternalInfoType InternalInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ScalarString;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class AggregateType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AggType;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Distinct;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ArithmeticType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ArithmeticOperationType Operation;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum ArithmeticOperationType
    {

        /// <remarks/>
        ADD,

        /// <remarks/>
        BIT_ADD,

        /// <remarks/>
        BIT_AND,

        /// <remarks/>
        BIT_COMBINE,

        /// <remarks/>
        BIT_NOT,

        /// <remarks/>
        BIT_OR,

        /// <remarks/>
        BIT_XOR,

        /// <remarks/>
        DIV,

        /// <remarks/>
        HASH,

        /// <remarks/>
        MINUS,

        /// <remarks/>
        MOD,

        /// <remarks/>
        MULT,

        /// <remarks/>
        SUB,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class AssignType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnReference", typeof(ColumnReferenceType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator", typeof(ScalarType), Order = 0)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ScalarType ScalarOperator;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CompareType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CompareOpType CompareOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum CompareOpType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("BINARY IS")]
        BINARYIS,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("BOTH NULL")]
        BOTHNULL,

        /// <remarks/>
        EQ,

        /// <remarks/>
        GE,

        /// <remarks/>
        GT,

        /// <remarks/>
        IS,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("IS NOT")]
        ISNOT,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("IS NOT NULL")]
        ISNOTNULL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("IS NULL")]
        ISNULL,

        /// <remarks/>
        LE,

        /// <remarks/>
        LT,

        /// <remarks/>
        NE,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("ONE NULL")]
        ONENULL,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ConstType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConstValue;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ConvertType
    {

        /// <remarks/>
        public ScalarExpressionType Style;

        /// <remarks/>
        public ScalarType ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DataType;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Length;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LengthSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Precision;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecisionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Scale;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScaleSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("Style")]
        public int Style1;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Implicit;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SetPredicateElementType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScalarExpressionType
    {

        /// <remarks/>
        public ScalarType ScalarOperator;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SetPredicateElementType : ScalarExpressionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SetPredicateType SetPredicateType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SetPredicateTypeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum SetPredicateType
    {

        /// <remarks/>
        Update,

        /// <remarks/>
        Insert,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ConditionalType
    {

        /// <remarks/>
        public ScalarExpressionType Condition;

        /// <remarks/>
        public ScalarExpressionType Then;

        /// <remarks/>
        public ScalarExpressionType Else;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class IdentType
    {

        /// <remarks/>
        public ColumnReferenceType ColumnReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Table;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class IntrinsicType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FunctionName;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class LogicalType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public LogicalOperationType Operation;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum LogicalOperationType
    {

        /// <remarks/>
        AND,

        /// <remarks/>
        IMPLIES,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("IS NOT NULL")]
        ISNOTNULL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("IS NULL")]
        ISNULL,

        /// <remarks/>
        IS,

        /// <remarks/>
        IsFalseOrNull,

        /// <remarks/>
        NOT,

        /// <remarks/>
        OR,

        /// <remarks/>
        XOR,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MultAssignType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Assign")]
        public AssignType[] Assign;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScalarExpressionListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScalarSequenceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FunctionName;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SubqueryType
    {

        /// <remarks/>
        public ScalarType ScalarOperator;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public SubqueryOperationType Operation;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RelOpType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] OutputList;

        /// <remarks/>
        public WarningsType Warnings;

        /// <remarks/>
        public MemoryFractionsType MemoryFractions;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RunTimeCountersPerThread", IsNullable = false)]
        public RunTimeInformationTypeRunTimeCountersPerThread[] RunTimeInformation;

        /// <remarks/>
        public RunTimePartitionSummaryType RunTimePartitionSummary;

        /// <remarks/>
        public InternalInfoType InternalInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Assert", typeof(FilterType))]
        [System.Xml.Serialization.XmlElementAttribute("BatchHashTableBuild", typeof(BatchHashTableBuildType))]
        [System.Xml.Serialization.XmlElementAttribute("Bitmap", typeof(BitmapType))]
        [System.Xml.Serialization.XmlElementAttribute("Collapse", typeof(CollapseType))]
        [System.Xml.Serialization.XmlElementAttribute("ComputeScalar", typeof(ComputeScalarType))]
        [System.Xml.Serialization.XmlElementAttribute("Concat", typeof(ConcatType))]
        [System.Xml.Serialization.XmlElementAttribute("ConstantScan", typeof(ConstantScanType))]
        [System.Xml.Serialization.XmlElementAttribute("CreateIndex", typeof(CreateIndexType))]
        [System.Xml.Serialization.XmlElementAttribute("DeletedScan", typeof(RowsetType))]
        [System.Xml.Serialization.XmlElementAttribute("Extension", typeof(UDXType))]
        [System.Xml.Serialization.XmlElementAttribute("Filter", typeof(FilterType))]
        [System.Xml.Serialization.XmlElementAttribute("ForeignKeyReferencesCheck", typeof(ForeignKeyReferencesCheckType))]
        [System.Xml.Serialization.XmlElementAttribute("Generic", typeof(GenericType))]
        [System.Xml.Serialization.XmlElementAttribute("Hash", typeof(HashType))]
        [System.Xml.Serialization.XmlElementAttribute("IndexScan", typeof(IndexScanType))]
        [System.Xml.Serialization.XmlElementAttribute("InsertedScan", typeof(RowsetType))]
        [System.Xml.Serialization.XmlElementAttribute("LogRowScan", typeof(RelOpBaseType))]
        [System.Xml.Serialization.XmlElementAttribute("Merge", typeof(MergeType))]
        [System.Xml.Serialization.XmlElementAttribute("MergeInterval", typeof(SimpleIteratorOneChildType))]
        [System.Xml.Serialization.XmlElementAttribute("NestedLoops", typeof(NestedLoopsType))]
        [System.Xml.Serialization.XmlElementAttribute("OnlineIndex", typeof(CreateIndexType))]
        [System.Xml.Serialization.XmlElementAttribute("Parallelism", typeof(ParallelismType))]
        [System.Xml.Serialization.XmlElementAttribute("ParameterTableScan", typeof(RelOpBaseType))]
        [System.Xml.Serialization.XmlElementAttribute("PrintDataflow", typeof(RelOpBaseType))]
        [System.Xml.Serialization.XmlElementAttribute("Put", typeof(PutType))]
        [System.Xml.Serialization.XmlElementAttribute("RemoteFetch", typeof(RemoteFetchType))]
        [System.Xml.Serialization.XmlElementAttribute("RemoteModify", typeof(RemoteModifyType))]
        [System.Xml.Serialization.XmlElementAttribute("RemoteQuery", typeof(RemoteQueryType))]
        [System.Xml.Serialization.XmlElementAttribute("RemoteRange", typeof(RemoteRangeType))]
        [System.Xml.Serialization.XmlElementAttribute("RemoteScan", typeof(RemoteType))]
        [System.Xml.Serialization.XmlElementAttribute("RowCountSpool", typeof(SpoolType))]
        [System.Xml.Serialization.XmlElementAttribute("ScalarInsert", typeof(ScalarInsertType))]
        [System.Xml.Serialization.XmlElementAttribute("Segment", typeof(SegmentType))]
        [System.Xml.Serialization.XmlElementAttribute("Sequence", typeof(SequenceType))]
        [System.Xml.Serialization.XmlElementAttribute("SequenceProject", typeof(ComputeScalarType))]
        [System.Xml.Serialization.XmlElementAttribute("SimpleUpdate", typeof(SimpleUpdateType))]
        [System.Xml.Serialization.XmlElementAttribute("Sort", typeof(SortType))]
        [System.Xml.Serialization.XmlElementAttribute("Split", typeof(SplitType))]
        [System.Xml.Serialization.XmlElementAttribute("Spool", typeof(SpoolType))]
        [System.Xml.Serialization.XmlElementAttribute("StreamAggregate", typeof(StreamAggregateType))]
        [System.Xml.Serialization.XmlElementAttribute("Switch", typeof(SwitchType))]
        [System.Xml.Serialization.XmlElementAttribute("TableScan", typeof(TableScanType))]
        [System.Xml.Serialization.XmlElementAttribute("TableValuedFunction", typeof(TableValuedFunctionType))]
        [System.Xml.Serialization.XmlElementAttribute("Top", typeof(TopType))]
        [System.Xml.Serialization.XmlElementAttribute("TopSort", typeof(TopSortType))]
        [System.Xml.Serialization.XmlElementAttribute("Update", typeof(UpdateType))]
        [System.Xml.Serialization.XmlElementAttribute("WindowAggregate", typeof(WindowAggregateType))]
        [System.Xml.Serialization.XmlElementAttribute("WindowSpool", typeof(WindowType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public RelOpBaseType Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double AvgRowSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimateCPU;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimateIO;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimateRebinds;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimateRewinds;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExecutionModeType EstimatedExecutionMode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EstimatedExecutionModeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool GroupExecuted;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GroupExecutedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimateRows;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public LogicalOpType LogicalOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NodeId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Parallel;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RemoteDataAccess;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RemoteDataAccessSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Partitioned;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartitionedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public PhysicalOpType PhysicalOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EstimatedTotalSubtreeCost;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double TableCardinality;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TableCardinalitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong StatsCollectionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatsCollectionIdSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class WarningsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnsWithNoStatistics", typeof(ColumnReferenceListType1))]
        [System.Xml.Serialization.XmlElementAttribute("HashSpillDetails", typeof(HashSpillDetailsType))]
        [System.Xml.Serialization.XmlElementAttribute("PlanAffectingConvert", typeof(AffectingConvertWarningType))]
        [System.Xml.Serialization.XmlElementAttribute("SortSpillDetails", typeof(SortSpillDetailsType))]
        [System.Xml.Serialization.XmlElementAttribute("SpillToTempDb", typeof(SpillToTempDbType))]
        [System.Xml.Serialization.XmlElementAttribute("Wait", typeof(WaitWarningType))]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NoJoinPredicate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NoJoinPredicateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SpatialGuess;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpatialGuessSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool UnmatchedIndexes;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnmatchedIndexesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool FullUpdateForOnlineIndexBuild;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FullUpdateForOnlineIndexBuildSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MemoryFractionsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Input;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Output;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RunTimeInformationTypeRunTimeCountersPerThread
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Thread;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int BrickId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BrickIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualRebinds;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualRebindsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualRewinds;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualRewindsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualRows;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualRowsRead;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualRowsReadSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong Batches;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchesSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualEndOfScans;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualExecutions;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExecutionModeType ActualExecutionMode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualExecutionModeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong TaskAddr;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TaskAddrSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong SchedulerId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SchedulerIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong FirstActiveTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FirstActiveTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong LastActiveTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastActiveTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong OpenTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpenTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong FirstRowTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FirstRowTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong LastRowTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastRowTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong CloseTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CloseTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualElapsedms;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualElapsedmsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualCPUms;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualCPUmsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualScans;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualScansSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualLogicalReads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualLogicalReadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualPhysicalReads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualPhysicalReadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualReadAheads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualReadAheadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualLobLogicalReads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualLobLogicalReadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualLobPhysicalReads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualLobPhysicalReadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualLobReadAheads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualLobReadAheadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SegmentReads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SegmentReadsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SegmentSkips;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SegmentSkipsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ActualLocallyAggregatedRows;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualLocallyAggregatedRowsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong InputMemoryGrant;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InputMemoryGrantSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong OutputMemoryGrant;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OutputMemoryGrantSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong UsedMemoryGrant;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UsedMemoryGrantSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum ExecutionModeType
    {

        /// <remarks/>
        Row,

        /// <remarks/>
        Batch,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RunTimePartitionSummaryType
    {

        /// <remarks/>
        public RunTimePartitionSummaryTypePartitionsAccessed PartitionsAccessed;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RunTimePartitionSummaryTypePartitionsAccessed
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PartitionRange")]
        public RunTimePartitionSummaryTypePartitionsAccessedPartitionRange[] PartitionRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong PartitionCount;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RunTimePartitionSummaryTypePartitionsAccessedPartitionRange
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong Start;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong End;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class FilterType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        public ScalarExpressionType Predicate;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool StartupExpression;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteQueryType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PutType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteModifyType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteFetchType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteRangeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BatchHashTableBuildType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SpoolType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WindowAggregateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WindowType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UDXType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TopType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SplitType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SequenceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SegmentType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NestedLoopsType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MergeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ConcatType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SwitchType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CollapseType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BitmapType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SortType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TopSortType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StreamAggregateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParallelismType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComputeScalarType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HashType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TableValuedFunctionType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ConstantScanType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FilterType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleIteratorOneChildType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RowsetType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ScalarInsertType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreateIndexType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleUpdateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IndexScanType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TableScanType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ForeignKeyReferencesCheckType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("DefinedValue", IsNullable = false)]
        public DefinedValuesListTypeDefinedValue[] DefinedValues;

        /// <remarks/>
        public InternalInfoType InternalInfo;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class DefinedValuesListTypeDefinedValue
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnReference", typeof(ColumnReferenceType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ValueVector", typeof(DefinedValuesListTypeDefinedValueValueVector), Order = 0)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnReference", typeof(ColumnReferenceType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator", typeof(ScalarType), Order = 1)]
        public object[] Items;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class DefinedValuesListTypeDefinedValueValueVector
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnReference")]
        public ColumnReferenceType[] ColumnReference;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class GenericType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteQueryType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PutType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteModifyType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteFetchType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RemoteRangeType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RemoteType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RemoteDestination;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RemoteSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RemoteObject;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PutType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RemoteQueryType : RemoteType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RemoteQuery;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class PutType : RemoteQueryType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RemoteModifyType : RemoteType
    {

        /// <remarks/>
        public ScalarExpressionType SetPredicate;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RemoteFetchType : RemoteType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RemoteRangeType : RemoteType
    {

        /// <remarks/>
        public SeekPredicatesType SeekPredicates;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SeekPredicatesType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicate", typeof(SeekPredicateType))]
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicateNew", typeof(SeekPredicateNewType))]
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicatePart", typeof(SeekPredicatePartType))]
        public object[] Items;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SeekPredicateType
    {

        /// <remarks/>
        public ScanRangeType Prefix;

        /// <remarks/>
        public ScanRangeType StartRange;

        /// <remarks/>
        public ScanRangeType EndRange;

        /// <remarks/>
        public SingleColumnReferenceType IsNotNull;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScanRangeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] RangeColumns;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ScalarOperator", IsNullable = false)]
        public ScalarType[] RangeExpressions;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CompareOpType ScanType;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SingleColumnReferenceType
    {

        /// <remarks/>
        public ColumnReferenceType ColumnReference;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SeekPredicateNewType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeekKeys")]
        public SeekPredicateType[] SeekKeys;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SeekPredicatePartType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicateNew")]
        public SeekPredicateNewType[] Items;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class BatchHashTableBuildType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool BitmapCreator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BitmapCreatorSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SpoolType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicate", typeof(SeekPredicateType))]
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicateNew", typeof(SeekPredicateNewType))]
        public object Item;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Stack;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StackSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int PrimaryNodeId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrimaryNodeIdSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class WindowAggregateType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class WindowType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UDXType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] UsedUDXColumns;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UDXName;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class TopType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] TieColumns;

        /// <remarks/>
        public ScalarExpressionType OffsetExpression;

        /// <remarks/>
        public ScalarExpressionType TopExpression;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RowCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Rows;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RowsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsPercent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsPercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool WithTies;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithTiesSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SplitType : RelOpBaseType
    {

        /// <remarks/>
        public SingleColumnReferenceType ActionColumn;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SequenceType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SegmentType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] GroupBy;

        /// <remarks/>
        public SingleColumnReferenceType SegmentColumn;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class NestedLoopsType : RelOpBaseType
    {

        /// <remarks/>
        public ScalarExpressionType Predicate;

        /// <remarks/>
        public ScalarExpressionType PassThru;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] OuterReferences;

        /// <remarks/>
        public SingleColumnReferenceType PartitionId;

        /// <remarks/>
        public SingleColumnReferenceType ProbeColumn;

        /// <remarks/>
        public StarJoinInfoType StarJoinInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Optimized;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool WithOrderedPrefetch;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithOrderedPrefetchSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool WithUnorderedPrefetch;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithUnorderedPrefetchSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StarJoinInfoType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Root;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RootSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StarJoinInfoTypeOperationType OperationType;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum StarJoinInfoTypeOperationType
    {

        /// <remarks/>
        Fetch,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Intersection")]
        IndexIntersection,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Filter")]
        IndexFilter,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Lookup")]
        IndexLookup,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MergeType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] InnerSideJoinColumns;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] OuterSideJoinColumns;

        /// <remarks/>
        public ScalarExpressionType Residual;

        /// <remarks/>
        public ScalarExpressionType PassThru;

        /// <remarks/>
        public StarJoinInfoType StarJoinInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ManyToMany;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ManyToManySpecified;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SwitchType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ConcatType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SwitchType : ConcatType
    {

        /// <remarks/>
        public ScalarExpressionType Predicate;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CollapseType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] GroupBy;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class BitmapType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] HashKeys;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TopSortType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SortType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("OrderByColumn", IsNullable = false)]
        public OrderByTypeOrderByColumn[] OrderBy;

        /// <remarks/>
        public SingleColumnReferenceType PartitionId;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Distinct;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class OrderByTypeOrderByColumn
    {

        /// <remarks/>
        public ColumnReferenceType ColumnReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Ascending;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class TopSortType : SortType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Rows;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StreamAggregateType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] GroupBy;

        /// <remarks/>
        public RollupInfoType RollupInfo;

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RollupInfoType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RollupLevel")]
        public RollupLevelType[] RollupLevel;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int HighestLevel;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RollupLevelType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Level;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ParallelismType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] PartitionColumns;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("OrderByColumn", IsNullable = false)]
        public OrderByTypeOrderByColumn[] OrderBy;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] HashKeys;

        /// <remarks/>
        public SingleColumnReferenceType ProbeColumn;

        /// <remarks/>
        public ScalarExpressionType Predicate;

        /// <remarks/>
        public ParallelismTypeActivation Activation;

        /// <remarks/>
        public ParallelismTypeBrickRouting BrickRouting;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public PartitionType PartitioningType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartitioningTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Remoting;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RemotingSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool LocalParallelism;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocalParallelismSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool InRow;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InRowSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ParallelismTypeActivation
    {

        /// <remarks/>
        public ObjectType Object;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ParallelismTypeActivationType Type;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FragmentElimination;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ObjectType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Server;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Database;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Schema;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Table;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Index;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Filtered;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FilteredSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Alias;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TableReferenceId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TableReferenceIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public IndexKindType IndexKind;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndexKindSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public CloneAccessScopeType CloneAccessScope;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CloneAccessScopeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StorageType Storage;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StorageSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum IndexKindType
    {

        /// <remarks/>
        Heap,

        /// <remarks/>
        Clustered,

        /// <remarks/>
        FTSChangeTracking,

        /// <remarks/>
        FTSMapping,

        /// <remarks/>
        NonClustered,

        /// <remarks/>
        PrimaryXML,

        /// <remarks/>
        SecondaryXML,

        /// <remarks/>
        Spatial,

        /// <remarks/>
        ViewClustered,

        /// <remarks/>
        ViewNonClustered,

        /// <remarks/>
        NonClusteredHash,

        /// <remarks/>
        SelectiveXML,

        /// <remarks/>
        SecondarySelectiveXML,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum CloneAccessScopeType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Both,

        /// <remarks/>
        Either,

        /// <remarks/>
        ExactMatch,

        /// <remarks/>
        Local,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum StorageType
    {

        /// <remarks/>
        RowStore,

        /// <remarks/>
        ColumnStore,

        /// <remarks/>
        MemoryOptimized,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum ParallelismTypeActivationType
    {

        /// <remarks/>
        CloneLocation,

        /// <remarks/>
        Resource,

        /// <remarks/>
        SingleBrick,

        /// <remarks/>
        Region,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ParallelismTypeBrickRouting
    {

        /// <remarks/>
        public ObjectType Object;

        /// <remarks/>
        public SingleColumnReferenceType FragmentIdColumn;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum PartitionType
    {

        /// <remarks/>
        Broadcast,

        /// <remarks/>
        Demand,

        /// <remarks/>
        Hash,

        /// <remarks/>
        NoPartitioning,

        /// <remarks/>
        Range,

        /// <remarks/>
        RoundRobin,

        /// <remarks/>
        CloneLocation,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ComputeScalarType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ComputeSequence;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComputeSequenceSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class HashType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] HashKeysBuild;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ColumnReference", IsNullable = false)]
        public ColumnReferenceType[] HashKeysProbe;

        /// <remarks/>
        public ScalarExpressionType BuildResidual;

        /// <remarks/>
        public ScalarExpressionType ProbeResidual;

        /// <remarks/>
        public StarJoinInfoType StarJoinInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelOp")]
        public RelOpType[] RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool BitmapCreator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BitmapCreatorSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class TableValuedFunctionType : RelOpBaseType
    {

        /// <remarks/>
        public ObjectType Object;

        /// <remarks/>
        public ScalarExpressionType Predicate;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ScalarOperator", IsNullable = false)]
        public ScalarType[] ParameterList;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ConstantScanType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Row", IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ScalarOperator", IsNullable = false, NestingLevel = 1)]
        public ScalarType[][] Values;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SimpleIteratorOneChildType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ScalarInsertType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreateIndexType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleUpdateType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IndexScanType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TableScanType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class RowsetType : RelOpBaseType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Object")]
        public ObjectType[] Object;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ScalarInsertType : RowsetType
    {

        /// <remarks/>
        public ScalarExpressionType SetPredicate;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DMLRequestSort;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMLRequestSortSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CreateIndexType : RowsetType
    {

        /// <remarks/>
        public RelOpType RelOp;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UpdateType : RowsetType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SetPredicate")]
        public SetPredicateElementType[] SetPredicate;

        /// <remarks/>
        public SingleColumnReferenceType ProbeColumn;

        /// <remarks/>
        public SingleColumnReferenceType ActionColumn;

        /// <remarks/>
        public SingleColumnReferenceType OriginalActionColumn;

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool WithOrderedPrefetch;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithOrderedPrefetchSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool WithUnorderedPrefetch;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WithUnorderedPrefetchSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DMLRequestSort;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMLRequestSortSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SimpleUpdateType : RowsetType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicate", typeof(SeekPredicateType))]
        [System.Xml.Serialization.XmlElementAttribute("SeekPredicateNew", typeof(SeekPredicateNewType))]
        public object Item;

        /// <remarks/>
        public ScalarExpressionType SetPredicate;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DMLRequestSort;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMLRequestSortSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class IndexScanType : RowsetType
    {

        /// <remarks/>
        public SeekPredicatesType SeekPredicates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Predicate")]
        public ScalarExpressionType[] Predicate;

        /// <remarks/>
        public SingleColumnReferenceType PartitionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Object", IsNullable = false)]
        public ObjectType[] IndexedViewInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Lookup;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LookupSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Ordered;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OrderType ScanDirection;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScanDirectionSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForcedIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForcedIndexSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForceSeek;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForceSeekSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ForceSeekColumnCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForceSeekColumnCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForceScan;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForceScanSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NoExpandHint;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NoExpandHintSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StorageType Storage;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StorageSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DynamicSeek;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DynamicSeekSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum OrderType
    {

        /// <remarks/>
        BACKWARD,

        /// <remarks/>
        FORWARD,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class TableScanType : RowsetType
    {

        /// <remarks/>
        public ScalarExpressionType Predicate;

        /// <remarks/>
        public SingleColumnReferenceType PartitionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Object", IsNullable = false)]
        public ObjectType[] IndexedViewInfo;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Ordered;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForcedIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForcedIndexSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ForceScan;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForceScanSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NoExpandHint;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NoExpandHintSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StorageType Storage;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StorageSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ForeignKeyReferencesCheckType : RelOpBaseType
    {

        /// <remarks/>
        public RelOpType RelOp;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ForeignKeyReferenceCheck")]
        public ForeignKeyReferenceCheckType[] ForeignKeyReferenceCheck;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ForeignKeyReferencesCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignKeyReferencesCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NoMatchingIndexCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NoMatchingIndexCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int PartialMatchingIndexCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartialMatchingIndexCountSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ForeignKeyReferenceCheckType
    {

        /// <remarks/>
        public IndexScanType IndexScan;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        Assert,

        /// <remarks/>
        BatchHashTableBuild,

        /// <remarks/>
        Bitmap,

        /// <remarks/>
        Collapse,

        /// <remarks/>
        ComputeScalar,

        /// <remarks/>
        Concat,

        /// <remarks/>
        ConstantScan,

        /// <remarks/>
        CreateIndex,

        /// <remarks/>
        DeletedScan,

        /// <remarks/>
        Extension,

        /// <remarks/>
        Filter,

        /// <remarks/>
        ForeignKeyReferencesCheck,

        /// <remarks/>
        Generic,

        /// <remarks/>
        Hash,

        /// <remarks/>
        IndexScan,

        /// <remarks/>
        InsertedScan,

        /// <remarks/>
        LogRowScan,

        /// <remarks/>
        Merge,

        /// <remarks/>
        MergeInterval,

        /// <remarks/>
        NestedLoops,

        /// <remarks/>
        OnlineIndex,

        /// <remarks/>
        Parallelism,

        /// <remarks/>
        ParameterTableScan,

        /// <remarks/>
        PrintDataflow,

        /// <remarks/>
        Put,

        /// <remarks/>
        RemoteFetch,

        /// <remarks/>
        RemoteModify,

        /// <remarks/>
        RemoteQuery,

        /// <remarks/>
        RemoteRange,

        /// <remarks/>
        RemoteScan,

        /// <remarks/>
        RowCountSpool,

        /// <remarks/>
        ScalarInsert,

        /// <remarks/>
        Segment,

        /// <remarks/>
        Sequence,

        /// <remarks/>
        SequenceProject,

        /// <remarks/>
        SimpleUpdate,

        /// <remarks/>
        Sort,

        /// <remarks/>
        Split,

        /// <remarks/>
        Spool,

        /// <remarks/>
        StreamAggregate,

        /// <remarks/>
        Switch,

        /// <remarks/>
        TableScan,

        /// <remarks/>
        TableValuedFunction,

        /// <remarks/>
        Top,

        /// <remarks/>
        TopSort,

        /// <remarks/>
        Update,

        /// <remarks/>
        WindowAggregate,

        /// <remarks/>
        WindowSpool,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum LogicalOpType
    {

        /// <remarks/>
        Aggregate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Anti Diff")]
        AntiDiff,

        /// <remarks/>
        Assert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Async Concat")]
        AsyncConcat,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Batch Hash Table Build")]
        BatchHashTableBuild,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Bitmap Create")]
        BitmapCreate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Scan")]
        ClusteredIndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Seek")]
        ClusteredIndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Update")]
        ClusteredUpdate,

        /// <remarks/>
        Collapse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Compute Scalar")]
        ComputeScalar,

        /// <remarks/>
        Concatenation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Constant Scan")]
        ConstantScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Cross Join")]
        CrossJoin,

        /// <remarks/>
        Delete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Deleted Scan")]
        DeletedScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Distinct Sort")]
        DistinctSort,

        /// <remarks/>
        Distinct,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Distribute Streams")]
        DistributeStreams,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Eager Spool")]
        EagerSpool,

        /// <remarks/>
        Filter,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Flow Distinct")]
        FlowDistinct,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Foreign Key References Check")]
        ForeignKeyReferencesCheck,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Full Outer Join")]
        FullOuterJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Gather Streams")]
        GatherStreams,

        /// <remarks/>
        Generic,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Scan")]
        IndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Seek")]
        IndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Inner Join")]
        InnerJoin,

        /// <remarks/>
        Insert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Inserted Scan")]
        InsertedScan,

        /// <remarks/>
        Intersect,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Intersect All")]
        IntersectAll,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Lazy Spool")]
        LazySpool,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Left Anti Semi Join")]
        LeftAntiSemiJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Left Diff")]
        LeftDiff,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Left Diff All")]
        LeftDiffAll,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Left Outer Join")]
        LeftOuterJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Left Semi Join")]
        LeftSemiJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Log Row Scan")]
        LogRowScan,

        /// <remarks/>
        Merge,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Merge Interval")]
        MergeInterval,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Merge Stats")]
        MergeStats,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Parameter Table Scan")]
        ParameterTableScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Partial Aggregate")]
        PartialAggregate,

        /// <remarks/>
        Print,

        /// <remarks/>
        Put,

        /// <remarks/>
        Rank,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Delete")]
        RemoteDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Index Scan")]
        RemoteIndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Index Seek")]
        RemoteIndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Insert")]
        RemoteInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Query")]
        RemoteQuery,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Scan")]
        RemoteScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Update")]
        RemoteUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Repartition Streams")]
        RepartitionStreams,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RID Lookup")]
        RIDLookup,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Right Anti Semi Join")]
        RightAntiSemiJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Right Diff")]
        RightDiff,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Right Diff All")]
        RightDiffAll,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Right Outer Join")]
        RightOuterJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Right Semi Join")]
        RightSemiJoin,

        /// <remarks/>
        Segment,

        /// <remarks/>
        Sequence,

        /// <remarks/>
        Sort,

        /// <remarks/>
        Split,

        /// <remarks/>
        Switch,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table-valued function")]
        Tablevaluedfunction,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Scan")]
        TableScan,

        /// <remarks/>
        Top,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TopN Sort")]
        TopNSort,

        /// <remarks/>
        UDX,

        /// <remarks/>
        Union,

        /// <remarks/>
        Update,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Local Stats")]
        LocalStats,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Window Spool")]
        WindowSpool,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Window Aggregate")]
        WindowAggregate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Key Lookup")]
        KeyLookup,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum PhysicalOpType
    {

        /// <remarks/>
        Assert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Batch Hash Table Build")]
        BatchHashTableBuild,

        /// <remarks/>
        Bitmap,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Delete")]
        ClusteredIndexDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Insert")]
        ClusteredIndexInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Scan")]
        ClusteredIndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Seek")]
        ClusteredIndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Update")]
        ClusteredIndexUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Index Merge")]
        ClusteredIndexMerge,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Clustered Update")]
        ClusteredUpdate,

        /// <remarks/>
        Collapse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Columnstore Index Delete")]
        ColumnstoreIndexDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Columnstore Index Insert")]
        ColumnstoreIndexInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Columnstore Index Merge")]
        ColumnstoreIndexMerge,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Columnstore Index Scan")]
        ColumnstoreIndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Columnstore Index Update")]
        ColumnstoreIndexUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Compute Scalar")]
        ComputeScalar,

        /// <remarks/>
        Concatenation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Constant Scan")]
        ConstantScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Deleted Scan")]
        DeletedScan,

        /// <remarks/>
        Filter,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Foreign Key References Check")]
        ForeignKeyReferencesCheck,

        /// <remarks/>
        Generic,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Hash Match")]
        HashMatch,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Delete")]
        IndexDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Insert")]
        IndexInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Scan")]
        IndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Seek")]
        IndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Spool")]
        IndexSpool,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Index Update")]
        IndexUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Inserted Scan")]
        InsertedScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Log Row Scan")]
        LogRowScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Merge Interval")]
        MergeInterval,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Merge Join")]
        MergeJoin,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Nested Loops")]
        NestedLoops,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Online Index Insert")]
        OnlineIndexInsert,

        /// <remarks/>
        Parallelism,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Parameter Table Scan")]
        ParameterTableScan,

        /// <remarks/>
        Print,

        /// <remarks/>
        Put,

        /// <remarks/>
        Rank,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Delete")]
        RemoteDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Index Scan")]
        RemoteIndexScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Index Seek")]
        RemoteIndexSeek,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Insert")]
        RemoteInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Query")]
        RemoteQuery,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Scan")]
        RemoteScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Update")]
        RemoteUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RID Lookup")]
        RIDLookup,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Row Count Spool")]
        RowCountSpool,

        /// <remarks/>
        Segment,

        /// <remarks/>
        Sequence,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Sequence Project")]
        SequenceProject,

        /// <remarks/>
        Sort,

        /// <remarks/>
        Split,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Stream Aggregate")]
        StreamAggregate,

        /// <remarks/>
        Switch,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Delete")]
        TableDelete,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Insert")]
        TableInsert,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Merge")]
        TableMerge,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Scan")]
        TableScan,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Spool")]
        TableSpool,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table Update")]
        TableUpdate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Table-valued function")]
        Tablevaluedfunction,

        /// <remarks/>
        Top,

        /// <remarks/>
        UDX,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Window Aggregate")]
        WindowAggregate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Window Spool")]
        WindowSpool,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Key Lookup")]
        KeyLookup,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum SubqueryOperationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("EQ ALL")]
        EQALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("EQ ANY")]
        EQANY,

        /// <remarks/>
        EXISTS,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GE ALL")]
        GEALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GE ANY")]
        GEANY,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GT ALL")]
        GTALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GT ANY")]
        GTANY,

        /// <remarks/>
        IN,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("LE ALL")]
        LEALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("LE ANY")]
        LEANY,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("LT ALL")]
        LTALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("LT ANY")]
        LTANY,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("NE ALL")]
        NEALL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("NE ANY")]
        NEANY,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UDTMethodType
    {

        /// <remarks/>
        public CLRFunctionType CLRFunction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class CLRFunctionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Assembly;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Class;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Method;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UDAggregateType
    {

        /// <remarks/>
        public ObjectType UDAggObject;

        /// <remarks/>
        public ScalarType ScalarOperator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Distinct;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UDFType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScalarOperator")]
        public ScalarType[] ScalarOperator;

        /// <remarks/>
        public CLRFunctionType CLRFunction;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FunctionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsClrFunction;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsClrFunctionSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class UnmatchedIndexesType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Object", IsNullable = false)]
        public ObjectType[] Parameterization;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class GuessedSelectivityType
    {

        /// <remarks/>
        public ObjectType Spatial;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ColumnType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ColumnId;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ColumnGroupType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Column")]
        public ColumnType[] Column;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ColumnGroupTypeUsage Usage;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum ColumnGroupTypeUsage
    {

        /// <remarks/>
        EQUALITY,

        /// <remarks/>
        INEQUALITY,

        /// <remarks/>
        INCLUDE,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MissingIndexType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ColumnGroup")]
        public ColumnGroupType[] ColumnGroup;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Database;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Schema;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Table;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class MissingIndexGroupType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MissingIndex")]
        public MissingIndexType[] MissingIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Impact;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ThreadReservationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NodeId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ReservedThreads;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ThreadStatType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ThreadReservation")]
        public ThreadReservationType[] ThreadReservation;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Branches;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int UsedThreads;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UsedThreadsSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class SetOptionsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ANSI_NULLS;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ANSI_NULLSSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ANSI_PADDING;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ANSI_PADDINGSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ANSI_WARNINGS;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ANSI_WARNINGSSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ARITHABORT;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ARITHABORTSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool CONCAT_NULL_YIELDS_NULL;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CONCAT_NULL_YIELDS_NULLSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NUMERIC_ROUNDABORT;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NUMERIC_ROUNDABORTSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool QUOTED_IDENTIFIER;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QUOTED_IDENTIFIERSpecified;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StmtReceiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StmtCursorType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StmtCondType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StmtUseDbType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StmtSimpleType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class BaseStmtInfoType
    {

        /// <remarks/>
        public SetOptionsType StatementSetOptions;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StatementCompId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementCompIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double StatementEstRows;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementEstRowsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StatementId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StatementOptmLevel;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BaseStmtInfoTypeStatementOptmEarlyAbortReason StatementOptmEarlyAbortReason;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementOptmEarlyAbortReasonSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CardinalityEstimationModelVersion;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double StatementSubTreeCost;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementSubTreeCostSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StatementText;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StatementType;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TemplatePlanGuideDB;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TemplatePlanGuideName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PlanGuideDB;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PlanGuideName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterizedText;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterizedPlanHandle;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string QueryHash;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string QueryPlanHash;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RetrievedFromCache;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StatementSqlHandle;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong DatabaseContextSettingsId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DatabaseContextSettingsIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong ParentObjectId;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ParentObjectIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BatchSqlHandle;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StatementParameterizationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatementParameterizationTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SecurityPolicyApplied;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SecurityPolicyAppliedSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum BaseStmtInfoTypeStatementOptmEarlyAbortReason
    {

        /// <remarks/>
        TimeOut,

        /// <remarks/>
        MemoryLimitExceeded,

        /// <remarks/>
        GoodEnoughPlanFound,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtReceiveType : BaseStmtInfoType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Operation", IsNullable = false)]
        public ReceivePlanTypeOperation[] ReceivePlan;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class ReceivePlanTypeOperation
    {

        /// <remarks/>
        public QueryPlanType QueryPlan;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ReceivePlanTypeOperationOperationType OperationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OperationTypeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public enum ReceivePlanTypeOperationOperationType
    {

        /// <remarks/>
        ReceivePlanSelect,

        /// <remarks/>
        ReceivePlanUpdate,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtCursorType : BaseStmtInfoType
    {

        /// <remarks/>
        public CursorPlanType CursorPlan;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtUseDbType : BaseStmtInfoType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Database;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtSimpleType : BaseStmtInfoType
    {

        /// <remarks/>
        public QueryPlanType QueryPlan;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UDF")]
        public FunctionType[] UDF;

        /// <remarks/>
        public FunctionType StoredProc;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtCondTypeThen
    {

        /// <remarks/>
        public StmtBlockType Statements;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan")]
    public partial class StmtCondTypeElse
    {

        /// <remarks/>
        public StmtBlockType Statements;
    }
}
