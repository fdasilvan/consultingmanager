import { Platform } from './platform.model';
import { User } from './user.model';
import { City } from './city.model';
import { CustomerCategory } from './customercategory.model';
import { Plan } from './plan.model';
import { CustomerSituation } from './customersituation.model';
import { CustomerLevel } from './customerlevel.model';
import { Team } from './team.model';

export class Customer {
  id: string;
  createdDate: Date;
  externalId: string;
  name: string;
  logoUrl: string;
  storeUrl: string;
  phone: string;
  email: string;
  customerFolderUrl: string;
  storeAnalysisUrl: string;
  meetingsDescription: string;
  subcategory: string;

  consultantId: string;
  consultant: User;

  cityId: string;
  city: City;

  platformId: string;
  platform: Platform;

  categoryId: string;
  category: CustomerCategory;

  planId: string;
  plan: Plan;

  situationId: string;
  sitaution: CustomerSituation;

  customerLevelId: string;
  customerLevel: CustomerLevel;

  teamId: string;
  team: Team;

  users: User[];

  constructor() {
  }
}
