export interface Plan {
  id: string;
  description: string;
  duration: number;
  meetingsDescription: string;
  implantationQuantity: string;
  implantationFrequency: string;
  consultingQuantity: string;
  consultingFrequency: string;
  reviewQuantity: string;
  reviewFrequency: string;
  allowGroupMeeting: boolean;
}
