import { KnowledgeLevel } from "../common/knowledge-level";
import { UserReadShort } from "../user/user-read-short";
import { WordRead } from "../word/word-read";

export interface Track {
  id: number;
  createdAt: Date;
  name: string;
  author: UserReadShort;
  description: string;
  level: KnowledgeLevel;
  words?: WordRead[];
}