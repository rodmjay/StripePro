﻿#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Users.Interfaces;

public interface IUser
{
    int Id { get; set; }
    string UserName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
}