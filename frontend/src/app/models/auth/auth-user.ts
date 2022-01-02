import { UserRoles } from "./user-roles";

export interface AuthUser {
  id: number;
  firebaseId: string;
  role: UserRoles;
  email: string;
  name: string;
  accessToken: string;
  refreshToken: string;
}