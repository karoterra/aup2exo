# aup2exo

[AviUtl](http://spring-fragrance.mints.ne.jp/aviutl/)
プロジェクトファイルから拡張編集のオブジェクトファイル (*.exo) を出力するコンソールアプリです。

## インストール

[Releases](https://github.com/karoterra/aup2exo/releases)
から最新版の ZIP ファイルをダウンロードし、好きな場所に展開してください。

.NET 6 ランタイムをインストール済みの方は `aup2exo-<バージョン>-win-x64-fd.zip` をダウンロードしてください。
.NET 6 ランタイムをインストールせずに利用する場合やよく分からない方は `aup2exo-<バージョン>-win-x64-sc.zip`
をダウンロードしてください。

アンインストール時には展開したフォルダを削除してください。

## 使い方

### コンソールを開かない場合

AviUtl プロジェクトファイル (*.aup) を `aup2exo.exe` にドラッグ&ドロップしてください。
プロジェクトファイルと同じ場所に `<元のファイル名>_<シーン番号>.exo` が出力されます。

### コンソールから使う場合

```
aup2exo 0.1.1
Copyright © 2021 karoterra
USAGE:
全てのシーンを出力:
  aup2exo C:\path\to\project.aup
出力先を指定:
  aup2exo --out C:\path\to\objects.exo C:\path\to\project.aup
Rootのみ出力:
  aup2exo --out C:\path\to\objects.exo --scene 0 C:\path\to\project.aup

  -o, --out            出力するexoファイルのパス

  -s, --scene          出力するシーンの番号(Rootなら0)

  --help               Display this help screen.

  --version            Display version information.

  Filename (pos. 0)    Required. aupファイルのパス
```

## 設定

フィルタプラグインによって追加されたフィルタオブジェクトの情報を出力するためには、 `setting.json` にフィルタオブジェクトの情報を保存しておく必要があります。
書式は以下の通りです。
```json
[
    {
        "name": "フィルタ名",
        "trackbars": [
            "トラックバー名1",
            "トラックバー名2"
        ],
        "checkboxes": [
            "チェックボックス名1",
            "チェックボックス名2"
        ]
    }
]
```

サンプルとして [PSDToolKit](https://github.com/oov/aviutl_psdtoolkit)
に同梱されている `チャンネルストリップ` と `Aux1 チャンネルストリップ`
についてあらかじめ記載してあるので、必要に応じて各自で追記してください。

## 更新履歴

更新履歴は [CHANGELOG](CHANGELOG.md) を参照してください。

## ライセンス
このソフトウェアは MIT ライセンスのもとで公開されます。
詳細は [LICENSE](LICENSE) を参照してください。

使用したライブラリ等については [CREDITS](CREDITS.md) を参照してください。
