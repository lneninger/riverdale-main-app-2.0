export interface EnumItem<TId> {
    key: TId;
    value: string;
    extras: { [key: string]: object;}
}