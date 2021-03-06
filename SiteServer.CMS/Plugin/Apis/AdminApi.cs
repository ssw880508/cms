﻿using System;
using System.Collections.Generic;
using System.Linq;
using SiteServer.CMS.Core;
using SiteServer.CMS.DataCache;
using SiteServer.CMS.Plugin.Impl;
using SiteServer.Plugin;

namespace SiteServer.CMS.Plugin.Apis
{
    public class AdminApi : IAdminApi
    {
        private AdminApi() { }

        private static AdminApi _instance;
        public static AdminApi Instance => _instance ?? (_instance = new AdminApi());

        public IAdministratorInfo GetAdminInfoByUserId(int userId)
        {
            return AdminManager.GetAdminInfoByUserId(userId);
        }

        public IAdministratorInfo GetAdminInfoByUserName(string userName)
        {
            return AdminManager.GetAdminInfoByUserName(userName);
        }

        public IAdministratorInfo GetAdminInfoByEmail(string email)
        {
            return AdminManager.GetAdminInfoByEmail(email);
        }

        public IAdministratorInfo GetAdminInfoByMobile(string mobile)
        {
            return AdminManager.GetAdminInfoByMobile(mobile);
        }

        public IAdministratorInfo GetAdminInfoByAccount(string account)
        {
            return AdminManager.GetAdminInfoByAccount(account);
        }

        public List<string> GetUserNameList()
        {
            return DataProvider.AdministratorDao.GetUserNameList().ToList();
        }

        public IPermissions GetPermissions(string userName)
        {
            return new PermissionsImpl(AdminManager.GetAdminInfoByUserName(userName));
        }

        public bool IsUserNameExists(string userName)
        {
            return DataProvider.AdministratorDao.IsUserNameExists(userName);
        }

        public bool IsEmailExists(string email)
        {
            return DataProvider.AdministratorDao.IsEmailExists(email);
        }

        public bool IsMobileExists(string mobile)
        {
            return DataProvider.AdministratorDao.IsMobileExists(mobile);
        }

        public string GetAccessToken(int userId, string userName, TimeSpan expiresAt)
        {
            return AuthenticatedRequest.GetAccessToken(userId, userName, expiresAt);
        }

        public string GetAccessToken(int userId, string userName, DateTime expiresAt)
        {
            return AuthenticatedRequest.GetAccessToken(userId, userName, expiresAt);
        }

        public IAccessToken ParseAccessToken(string accessToken)
        {
            return AuthenticatedRequest.ParseAccessToken(accessToken);
        }
    }
}
