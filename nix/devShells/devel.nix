{
  pkgs,
  inputs',
  ...
}:
pkgs.mkShell {
  stdenv = pkgs.stdenvNoCc;
  nativeBuildInputs = with pkgs; [
    dotnetCorePackages.dotnet_10.sdk
    nodePackages.mermaid-cli
    nodejs
    http-server
    inputs'.nixpkgs-reveal-md.legacyPackages.reveal-md
  ];
}
