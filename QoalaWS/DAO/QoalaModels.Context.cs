﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QoalaWS.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QoalaEntities : DbContext
    {
        public QoalaEntities()
            : base("name=QoalaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comment> COMMENTS { get; set; }
        public virtual DbSet<DEVICE_GEO_LOCATIONS> DEVICE_GEO_LOCATIONS { get; set; }
        public virtual DbSet<DEVICE> DEVICES { get; set; }
        public virtual DbSet<Post> POSTS { get; set; }
        public virtual DbSet<User> USERS { get; set; }
        public virtual DbSet<AccessControl> ACCESSCONTROLs { get; set; }
    
        public virtual int SP_DELETE_USER(Nullable<decimal> iD, ObjectParameter rOWCOUNT)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DELETE_USER", iDParameter, rOWCOUNT);
        }
    
        public virtual int SP_UPDATE_USER(Nullable<decimal> pID, string pNAME, string pPASSWORD, string pEMAIL, Nullable<decimal> pPERMISSION, ObjectParameter pROWCOUNT)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(decimal));
    
            var pNAMEParameter = pNAME != null ?
                new ObjectParameter("PNAME", pNAME) :
                new ObjectParameter("PNAME", typeof(string));
    
            var pPASSWORDParameter = pPASSWORD != null ?
                new ObjectParameter("PPASSWORD", pPASSWORD) :
                new ObjectParameter("PPASSWORD", typeof(string));
    
            var pEMAILParameter = pEMAIL != null ?
                new ObjectParameter("PEMAIL", pEMAIL) :
                new ObjectParameter("PEMAIL", typeof(string));
    
            var pPERMISSIONParameter = pPERMISSION.HasValue ?
                new ObjectParameter("PPERMISSION", pPERMISSION) :
                new ObjectParameter("PPERMISSION", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UPDATE_USER", pIDParameter, pNAMEParameter, pPASSWORDParameter, pEMAILParameter, pPERMISSIONParameter, pROWCOUNT);
        }
    
        public virtual int SP_USER_LOG(string lOG, Nullable<decimal> uSER_ID)
        {
            var lOGParameter = lOG != null ?
                new ObjectParameter("LOG", lOG) :
                new ObjectParameter("LOG", typeof(string));
    
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USER_LOG", lOGParameter, uSER_IDParameter);
        }
    
        public virtual int SP_INSERT_USER(string nAME, string pASSWORD, string eMAIL, Nullable<decimal> pERMISSION, ObjectParameter oUT_ID_USER)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var pERMISSIONParameter = pERMISSION.HasValue ?
                new ObjectParameter("PERMISSION", pERMISSION) :
                new ObjectParameter("PERMISSION", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_USER", nAMEParameter, pASSWORDParameter, eMAILParameter, pERMISSIONParameter, oUT_ID_USER);
        }
    
        public virtual int SP_DELETE_POST(Nullable<decimal> iD, ObjectParameter rOWCOUNT)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DELETE_POST", iDParameter, rOWCOUNT);
        }
    
        public virtual int SP_INSERT_POST(string tITLE, string cONTENT, Nullable<decimal> iD_USER, ObjectParameter oUT_ID_POST)
        {
            var tITLEParameter = tITLE != null ?
                new ObjectParameter("TITLE", tITLE) :
                new ObjectParameter("TITLE", typeof(string));
    
            var cONTENTParameter = cONTENT != null ?
                new ObjectParameter("CONTENT", cONTENT) :
                new ObjectParameter("CONTENT", typeof(string));
    
            var iD_USERParameter = iD_USER.HasValue ?
                new ObjectParameter("ID_USER", iD_USER) :
                new ObjectParameter("ID_USER", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_POST", tITLEParameter, cONTENTParameter, iD_USERParameter, oUT_ID_POST);
        }
    
        public virtual int SP_POST_LOG(string lOG, Nullable<decimal> pOST_ID)
        {
            var lOGParameter = lOG != null ?
                new ObjectParameter("LOG", lOG) :
                new ObjectParameter("LOG", typeof(string));
    
            var pOST_IDParameter = pOST_ID.HasValue ?
                new ObjectParameter("POST_ID", pOST_ID) :
                new ObjectParameter("POST_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_POST_LOG", lOGParameter, pOST_IDParameter);
        }
    
        public virtual int SP_PUBLISH_POST(Nullable<decimal> iD, ObjectParameter rOWCOUNT)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_PUBLISH_POST", iDParameter, rOWCOUNT);
        }
    
        public virtual int SP_UPDATE_POST(Nullable<decimal> pID, string pTITLE, string pCONTENT, Nullable<decimal> pID_USER, ObjectParameter rOWCOUNT)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(decimal));
    
            var pTITLEParameter = pTITLE != null ?
                new ObjectParameter("PTITLE", pTITLE) :
                new ObjectParameter("PTITLE", typeof(string));
    
            var pCONTENTParameter = pCONTENT != null ?
                new ObjectParameter("PCONTENT", pCONTENT) :
                new ObjectParameter("PCONTENT", typeof(string));
    
            var pID_USERParameter = pID_USER.HasValue ?
                new ObjectParameter("PID_USER", pID_USER) :
                new ObjectParameter("PID_USER", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UPDATE_POST", pIDParameter, pTITLEParameter, pCONTENTParameter, pID_USERParameter, rOWCOUNT);
        }
    
        public virtual int SP_APPROVE_COMMENT(Nullable<decimal> pID, ObjectParameter rOWCOUNT)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_APPROVE_COMMENT", pIDParameter, rOWCOUNT);
        }
    
        public virtual int SP_COMMENT_LOG(string pLOG, Nullable<decimal> pCOMMENT_ID)
        {
            var pLOGParameter = pLOG != null ?
                new ObjectParameter("PLOG", pLOG) :
                new ObjectParameter("PLOG", typeof(string));
    
            var pCOMMENT_IDParameter = pCOMMENT_ID.HasValue ?
                new ObjectParameter("PCOMMENT_ID", pCOMMENT_ID) :
                new ObjectParameter("PCOMMENT_ID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_COMMENT_LOG", pLOGParameter, pCOMMENT_IDParameter);
        }
    
        public virtual int SP_DELETE_COMMENT(Nullable<decimal> pID, ObjectParameter rOWCOUNT)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_DELETE_COMMENT", pIDParameter, rOWCOUNT);
        }
    
        public virtual int SP_INSERT_COMMENT(string pCONTENT, Nullable<decimal> pID_USER, Nullable<decimal> pID_POST, ObjectParameter oUT_ID_COMMENT)
        {
            var pCONTENTParameter = pCONTENT != null ?
                new ObjectParameter("PCONTENT", pCONTENT) :
                new ObjectParameter("PCONTENT", typeof(string));
    
            var pID_USERParameter = pID_USER.HasValue ?
                new ObjectParameter("PID_USER", pID_USER) :
                new ObjectParameter("PID_USER", typeof(decimal));
    
            var pID_POSTParameter = pID_POST.HasValue ?
                new ObjectParameter("PID_POST", pID_POST) :
                new ObjectParameter("PID_POST", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_COMMENT", pCONTENTParameter, pID_USERParameter, pID_POSTParameter, oUT_ID_COMMENT);
        }
    
        public virtual int SP_UPDATE_COMMENT(Nullable<decimal> pID, string pCONTENT, Nullable<decimal> pID_USER, Nullable<decimal> pID_POST, ObjectParameter rOWCOUNT)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(decimal));
    
            var pCONTENTParameter = pCONTENT != null ?
                new ObjectParameter("PCONTENT", pCONTENT) :
                new ObjectParameter("PCONTENT", typeof(string));
    
            var pID_USERParameter = pID_USER.HasValue ?
                new ObjectParameter("PID_USER", pID_USER) :
                new ObjectParameter("PID_USER", typeof(decimal));
    
            var pID_POSTParameter = pID_POST.HasValue ?
                new ObjectParameter("PID_POST", pID_POST) :
                new ObjectParameter("PID_POST", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UPDATE_COMMENT", pIDParameter, pCONTENTParameter, pID_USERParameter, pID_POSTParameter, rOWCOUNT);
        }
    }
}
