import { KnowledgeLevel } from "../common/knowledge-level";
import { UserReadShort } from "../user/user-read-short";

export interface TrackCardRead {
  id: number;
  createdAt: Date;
  name: string;
  author: UserReadShort;
  description: string;
  level: KnowledgeLevel;
  amount: number;
  rank: number;
}