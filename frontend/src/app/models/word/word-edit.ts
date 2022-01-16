import { Example } from "../examples/example";

export interface WordEdit {
  id: number;
  text: string;
  transcription: string;
  translation: string;
  examples: Example[]
}