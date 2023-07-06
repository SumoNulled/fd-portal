using System;

namespace FDPortal.Model.Database
{
    class Config
    {
        private String dataSource = "FrontDeskPortal.db";
        private String password = "";

        public String getDataSource() { return dataSource; }
        public String getPassword() { return password; }
    }
}
