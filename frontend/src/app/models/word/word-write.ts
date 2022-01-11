import { Example } from "../examples/example";

export interface WordWrite {
  text: string;
  transcription: string;
  translation: string;
  examples: Example[]
}