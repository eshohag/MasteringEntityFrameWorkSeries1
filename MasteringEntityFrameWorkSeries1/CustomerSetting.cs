//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasteringEntityFrameWorkSeries1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerSetting
    {
        public string CustomerId { get; set; }
        public string Setting { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
