import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateSerieDto {
  title?: string;
  year?: string;
  poster?: string;
  imdbID?: string;
}

export interface SerieDto extends EntityDto<number> {
  title?: string;
  year?: string;
  poster?: string;
  imdbID?: string;
}
