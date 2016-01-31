using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

using Sirc.SharpReport.IDAL;
using Sirc.SharpReport.Model;
using Sirc.SharpReport.SQLServerDAL;

namespace Sirc.SharpReport.DALFactory
{
    /// <summary>
    /// 构造DAL的工厂类
    /// </summary>
    public sealed class DataAccess
    {
        // Look up the DAL implementation we should be using
        //private static readonly string path = ConfigurationManager.AppSettings["DAL"];
        private static readonly string path = "Sirc.SharpReport.SQLServerDAL";
        private static readonly string strNamespace = "Sirc.SharpReport.SQLServerDAL";


        private DataAccess()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDimTime CreateDimTime()
        {
            string className = strNamespace + ".DimTime";
            return (IDimTime)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICostCategory CreateCostCategory()
        {
            string className = strNamespace + ".CostCategory";
            return (ICostCategory)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICostProperty CreateCostProperty()
        {
            string className = strNamespace + ".CostProperty";
            return (ICostProperty)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPort CreatePort()
        {
            string className = strNamespace + ".Port";
            return (IPort)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPortType CreatePortType()
        {
            string className = strNamespace + ".PortType";
            return (IPortType)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IReportType CreateReportType()
        {
            string className = strNamespace + ".ReportType";
            return (IReportType)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IRoute CreateRoute()
        {
            string className = strNamespace + ".Route";
            return (IRoute)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IVoyage CreateVoyage()
        {
            string className = strNamespace + ".Voyage";
            return (IVoyage)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISampleReport CreateSampleReport()
        {
            string className = strNamespace + ".SampleReport";
            return (ISampleReport)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IShip CreateShip()
        {
            string className = strNamespace + ".Ship";
            return (IShip)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IOilType CreateOilType()
        {
            string className = strNamespace + ".OilType";
            return (IOilType)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IRelation_RoutePort CreateRelation_RoutePort()
        {
            string className = strNamespace + ".Relation_RoutePort";
            return (IRelation_RoutePort)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// VoyageConsume
        /// </summary>
        /// <returns></returns>
        public static IVoyageConsume CreateVoyageConsume()
        {
            string className = strNamespace + ".VoyageConsume";
            return (IVoyageConsume)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// OilUseBalance
        /// </summary>
        /// <returns></returns>
        public static IOilUseBalance CreateOilUseBalance()
        {
            string className = strNamespace + ".OilUseBalance";
            return (IOilUseBalance)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// HangciBaseInput
        /// </summary>
        /// <returns></returns>
        public static IHangciBaseInput CreateHangciBaseInput()
        {
            string className = strNamespace + ".HangciBaseInput";
            return (IHangciBaseInput)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// VoyageLoad
        /// </summary>
        /// <returns></returns>
        public static IVoyageLoad CreateVoyageLoad()
        {
            string className = strNamespace + ".VoyageLoad";
            return (IVoyageLoad)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 物料
        /// </summary>
        /// <returns></returns>
        public static IWuliaoInput CreateWuliaoInput()
        {
            string className = strNamespace + ".WuliaoInput";
            return (IWuliaoInput)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 备件
        /// </summary>
        /// <returns></returns>
        public static IBeijianInput CreateBeijianInput()
        {
            string className = strNamespace + ".BeijianInput";
            return (IBeijianInput)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 修理
        /// </summary>
        /// <returns></returns>
        public static IXiuliInput CreateXiuliInput()
        {
            string className = strNamespace + ".XiuliInput";
            return (IXiuliInput)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 检验
        /// </summary>
        /// <returns></returns>
        public static IJianyanInput CreateJianyanInput()
        {
            string className = strNamespace + ".JianyanInput";
            return (IJianyanInput)Assembly.Load(path).CreateInstance(className);
        }
        /// <summary>
        /// 发票
        /// </summary>
        /// <returns></returns>
        public static IInvoice CreateInvoice()
        {
            string className = strNamespace + ".Invoice";
            return (IInvoice)Assembly.Load(path).CreateInstance(className);
        }


        public static ICurrency CreateCurrency()
        {
            string className = strNamespace + ".Currency";
            return (ICurrency)Assembly.Load(path).CreateInstance(className);
        }

        public static IManagerType CreateManagerType()
        {
            string className = strNamespace + ".ManagerType";
            return (IManagerType)Assembly.Load(path).CreateInstance(className);
        }

        public static IExchangeRate CreateExchangeRate()
        {
            string className = strNamespace + ".ExchangeRate";
            return (IExchangeRate)Assembly.Load(path).CreateInstance(className);
        }

        public static IInsuranceOfFreightTransport CreateInsuranceOfFreightTransport()
        {
            string className = strNamespace + ".InsuranceOfFreightTransport";
            return (IInsuranceOfFreightTransport)Assembly.Load(path).CreateInstance(className);
        }
        public static IInsuranceOfCompensation CreateInsuranceOfCompensation()
        {
            string className = strNamespace + ".InsuranceOfCompensation";
            return (IInsuranceOfCompensation)Assembly.Load(path).CreateInstance(className);
        }

        public static IContainer CreateContainer()
        {
            string className = strNamespace + ".Container";
            return (IContainer)Assembly.Load(path).CreateInstance(className);
        }


        public static IInstalmentOfCompensation CreateInstalmentOfCompensation()
        {
            string className = strNamespace + ".InstalmentOfCompensation";
            return (IInstalmentOfCompensation)Assembly.Load(path).CreateInstance(className);
        }

        public static IInsuranceOfContainer CreateInsuranceOfContainer()
        {
            string className = strNamespace + ".InsuranceOfContainer";
            return (IInsuranceOfContainer)Assembly.Load(path).CreateInstance(className);
        }

        public static ICertificateFlee CreateCertificateFlee()
        {
            string className = strNamespace + ".CertificateFlee";
            return (ICertificateFlee)Assembly.Load(path).CreateInstance(className);

        }
        
        public static ICommonFee CreateCommonFee()
        {
            string className = strNamespace + ".CommonFee";
            return (ICommonFee)Assembly.Load(path).CreateInstance(className);
        }

        public static IFeeCatalog CreateFeeCatalog()
        {
            string className = strNamespace + ".FeeCatalog";
            return (IFeeCatalog)Assembly.Load(path).CreateInstance(className);
        }

        public static IOilFeeReport CreateOilFeeReport()
        {
            string className = strNamespace + ".OilFeeReport";
            return (IOilFeeReport)Assembly.Load(path).CreateInstance(className);
        }

        public static IOilTypeFee CreateOilTypeFee()
        {
            string className = strNamespace + ".OilTypeFee";
            return (IOilTypeFee)Assembly.Load(path).CreateInstance(className);
        }

        public static IVoyageFCL CreateVoyageFCL()
        {
            string className = strNamespace + ".VoyageFCL";
            return (IVoyageFCL)Assembly.Load(path).CreateInstance(className);
        }

        public static IVoyageLCL CreateVoyageLCL()
        {
            string className = strNamespace + ".VoyageLCL";
            return (IVoyageLCL)Assembly.Load(path).CreateInstance(className);
        }

        public static IVoyageOther CreateVoyageOther()
        {
            string className = strNamespace + ".VoyageOther";
            return (IVoyageOther)Assembly.Load(path).CreateInstance(className);
        }

        public static IRentShipReport CreateRentShipReport()
        {
            string className = strNamespace + ".RentShipReport";
            return (IRentShipReport)Assembly.Load(path).CreateInstance(className);
        }

        public static IRentContainerReport CreateRentContainerReport()
        {
            string className = strNamespace + ".RentContainerReport";
            return (IRentContainerReport)Assembly.Load(path).CreateInstance(className);
        }

        public static IRentContainer CreateRentContainer()
        {
            string className = strNamespace + ".RentContainer";
            return (IRentContainer)Assembly.Load(path).CreateInstance(className);
        }

        public static IFCLCustomer CreateFCLCustomer()
        {
            string className = strNamespace + ".FCLCustomer";
            return (IFCLCustomer)Assembly.Load(path).CreateInstance(className);
        }
    }

    public sealed class DataAccess<T>
    {
        public static IFormLibrary<T> CreateFormLibrary()
        {
            IFormLibrary<T> dal = new FormLibrary<T>();
            return dal;
        }
    }

}
