
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class TransactionQueryClass : TConnection
{


        public bool Execute_TRANSACTION(string TransactionQueryString)
        {
        // TransactionQueryString = "";              // خالی کردن متغیر برای کوئری های بعدی

        this.CommandText = " Use DBShalikoubi " + 
            " BEGIN TRY   " + 
            " BEGIN TRANSACTION   " + 
            " " + TransactionQueryString + " " + 
            " COMMIT  " + " END TRY BEGIN  " + 
            " CATCH 	 " + 
            " IF @@TRANCOUNT > 0  " + 
            " ROLLBACK  " + " END CATCH	 ";
        return this.Execute();

        }
    
}
