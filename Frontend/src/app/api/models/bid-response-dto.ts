/* tslint:disable */
/* eslint-disable */
import { ItemResponseDto } from './item-response-dto';
import { UserResponseDto } from './user-response-dto';
export interface BidResponseDto {
  bidPrice?: number;
  itemResponse?: ItemResponseDto;
  userResponse?: UserResponseDto;
}
