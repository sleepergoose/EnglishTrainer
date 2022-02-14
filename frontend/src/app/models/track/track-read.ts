import { KnowledgeLevel } from "../common/knowledge-level";
import { PhrasalVerbRead } from "../phrasal-verb/phrasal-verb-read";
import { UserReadShort } from "../user/user-read-short";
import { WordRead } from "../word/word-read";

export interface TrackRead {
  id: number;
  createdAt: Date;
  name: string;
  author: UserReadShort;
  description: string;
  level: KnowledgeLevel;
  words?: WordRead[];
}

export interface PvTrackRead {
  id: number;
  createdAt: Date;
  name: string;
  author: UserReadShort;
  description: string;
  level: KnowledgeLevel;
  words?: PhrasalVerbRead[];
}