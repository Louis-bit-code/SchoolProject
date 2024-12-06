﻿namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public interface IUserStore
{
    bool AuthenticateUser(string username, string password);
    bool RegisterUser(string username, string password);
}