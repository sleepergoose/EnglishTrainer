import { Example } from "../examples/example";

export interface PhrasalVerbRead {
  id: number;
  text: string;
  translation: string;
  examples: Example[]
}