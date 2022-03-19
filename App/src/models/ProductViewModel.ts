import { ParametersDto } from "./ParametersDto";

export interface ProductViewModel {
  category: string;
  id: string;
  images: string;
  name: string;
  parameters: ParametersDto[];
}
