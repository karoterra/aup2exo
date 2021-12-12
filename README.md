# aup2exo

[AviUtl](http://spring-fragrance.mints.ne.jp/aviutl/)
プロジェクトファイルから拡張編集のオブジェクトファイル (*.exo) を出力するコンソールアプリです。

## 使い方

### コンソールを開かない場合

AviUtl プロジェクトファイル (*.aup) を `aup2exo.exe` にドラッグ&ドロップしてください。
プロジェクトファイルと同じ場所に `<元のファイル名>_<シーン番号>.exo` が出力されます。

### コンソールから使う場合
```
aup2exo 0.0.0
Copyright © 2021 karoterra

  -o, --out            出力するexoファイルのパス

  -s, --scene          出力するシーンの番号(Rootなら0)

  --help               Display this help screen.

  --version            Display version information.

  Filename (pos. 0)    Required. aupファイルのパス
```

## ライセンス
このソフトウェアは MIT ライセンスのもとで公開されます。
詳細は [LICENSE](LICENSE) を参照してください。

使用したライブラリ等については [CREDITS](CREDITS.md) を参照してください。
