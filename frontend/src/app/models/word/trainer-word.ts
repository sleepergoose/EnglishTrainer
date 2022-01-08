import { WordExample } from "../example/word-example";

export interface TrainerWord {
  id: number;
  text: string;
  transcription: string;
  translation: string;
  examples: WordExample[]
}