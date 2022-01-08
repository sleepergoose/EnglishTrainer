import { Example } from "../examples/example";

export interface TrainerWord {
  id: number;
  text: string;
  translation: string;
  examples: Example[]
}