# NKODICE Clone
[NKODICE](https://store.steampowered.com/app/1510950/NKODICE/?l=japanese)のクローンを作りたい

[![Image from Gyazo](https://i.gyazo.com/223942d12d13cebe1b1d04eaaba9cf6d.gif)](https://gyazo.com/223942d12d13cebe1b1d04eaaba9cf6d)

## サイコロの出目を調べる
<img src="https://user-images.githubusercontent.com/40447362/128225808-de94f080-0176-4f05-adf0-3845f1aebe64.png" width=640>

いろんな方法がある。
- https://qiita.com/FW14B/items/29f125069a6359ea76a9
- https://hacchi-man.hatenablog.com/entry/2020/06/19/220000

内積を使う方法とかが賢そうだが、単に出目を調べるだけならそんな面倒なことをしなくてもいい。

アイデアとしては、サイコロの上に向いている軸がどの軸で、それが正負のどちらかが分かれば、出目の判定ができる。

`diceTransform.InverseTransformDirection(Vector3.up)`で、ワールド座標の上（+y方向）をサイコロのローカル座標系に変換する。
変換した結果、どの軸の値（の絶対値）が最も大きいか調べることで、接地している面とその反対の面が判断できる。

そこから、ベクトルの正負を見ることでどの面が上を向いているかを判別する。

## 出目の中に特定の組みがあるか調べる
<img src="https://user-images.githubusercontent.com/40447362/128225471-1f00d15c-0895-42b0-9b75-356ca5799a37.png" width=480>

複数のサイコロの出目が分かれば、その中に特定の組み合わせが存在するか調べる必要がある。

はじめ下のコードのようにPythonで試し書きをした際は、出目から考えられるすべての組み合わせを求めて、その中に特定の組み合わせが存在するかの判定をしようとしていた。

<img src="https://user-images.githubusercontent.com/40447362/128228492-854f5ad4-b3d2-4456-86a6-e80326a76eac.png" width=640>

しかし、組み合わせを考えるのが計算量的に大変なことや、C#のコードへの落とし込みが面倒で別の方向性で進めることにした。

判定したい組み合わせの要素のリストを1つ1つ見ていき、それが出目のリストの中に含まれていれば削除する。組み合わせの要素が含まれていなければ、`false`を返し、全て削除することができれば`true`を返すことで、出目の中に特定の組み合わせが存在するか判定することができる。

ここでリストの要素を削除しながら判定を行うため、`new List<string>(givenList)`で予めリストをコピーしておく必要がある。そのまま削除してしまえば、参照でアクセスしているため大元のリストからも要素が消えてしまい複数の組み合わせの判定ができなくなってしまう。

## NKODICE
本家はグラフィック面やUI、演出のこだわりがすごい。ぜひ遊んでみてほしい。

[![](https://user-images.githubusercontent.com/40447362/128229998-a361ef8d-2520-439e-913f-4c2850a8ede8.png)](https://store.steampowered.com/app/1510950/NKODICE/?l=japanese)

🔗https://store.steampowered.com/app/1510950/NKODICE/?l=japanese
