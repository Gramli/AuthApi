export interface IUserLogin {
    name: string;
    password: string;
}

export interface IRegisterUser extends IUserLogin {
    email: string;
}

export type SubmitedUser = IUserLogin | IRegisterUser;

export interface IUser{
    name: string;
    role: string;
}