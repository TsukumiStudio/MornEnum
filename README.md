# MornEnum

## 概要

文字列ベースの型安全なEnum管理およびInspectorで選択可能なEnum実装ライブラリ。

## 依存関係

| 種別 | 名前 |
|------|------|
| Mornライブラリ | MornGlobal |

## 使い方

### カスタムEnumクラスの作成

```csharp
public class MyEnum : MornEnumBase
{
    protected override string[] Values => new[] { "Option1", "Option2", "Option3" };
}
```

### Inspector用Drawerの作成

```csharp
[CustomPropertyDrawer(typeof(MyEnum))]
public class MyEnumDrawer : MornEnumDrawerBase
{
    protected override string[] Values => new[] { "Option1", "Option2", "Option3" };
    protected override Object PingTarget => null;
}
```

### 標準Enumユーティリティ

```csharp
// Enum値の個数を取得
var count = MornEnumUtil<MyEnumType>.Count;

// 全ての値を取得
var values = MornEnumUtil<MyEnumType>.Values;

// キャッシュ付き文字列変換
var str = MornEnumUtil<MyEnumType>.CachedToString(value);
```
