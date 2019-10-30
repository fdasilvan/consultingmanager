export interface Plan {
  id: string;
  description: string;
  duration: number;
  meetingsDescription: string;
  implantationQuantity: number;
  implantationFrequency: number;
  consultingQuantity: number;
  consultingFrequency: number;
  reviewQuantity: number;
  reviewFrequency: number;
  allowGroupMeeting: boolean;
}
