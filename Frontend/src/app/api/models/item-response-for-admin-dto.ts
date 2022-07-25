/* tslint:disable */
/* eslint-disable */
import { BidResponseForAdminDto } from './bid-response-for-admin-dto';
export interface ItemResponseForAdminDto {
  bidsOnItem?: null | Array<BidResponseForAdminDto>;
  desc?: null | string;
  endTime?: null | number;
  gallery?: null | Array<number>;
  id?: number;
  initialPrice?: null | number;
  name?: null | string;
}
