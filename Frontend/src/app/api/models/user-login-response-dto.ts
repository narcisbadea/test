/* tslint:disable */
/* eslint-disable */
import { UserResponseDto } from './user-response-dto';
export interface UserLoginResponseDto {
  roles?: null | Array<string>;
  token?: null | string;
  userResponse?: UserResponseDto;
}
