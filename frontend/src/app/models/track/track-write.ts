import { KnowledgeLevel } from "../common/knowledge-level";

export interface TrackWrite {
  name: string;
  authorId: number;
  description: string;
  level: KnowledgeLevel;
}