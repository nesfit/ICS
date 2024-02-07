{
  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-23.11";
    nixpkgs-unstable.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = {
    self,
    nixpkgs,
    nixpkgs-unstable,
    flake-utils,
  }:
    flake-utils.lib.eachDefaultSystem (
      system: let
        pkgs = nixpkgs.legacyPackages.${system};
        dotnet-combined =
          (with pkgs.dotnetCorePackages;
            combinePackages [
              sdk_8_0
            ])
          .overrideAttrs (finalAttrs: previousAttrs: {
            # This is needed to install workload in $HOME
            # https://discourse.nixos.org/t/dotnet-maui-workload/20370/2

            # postBuild =
            #   (previousAttrs.postBuild or '''')
            #   + ''

            #     for i in $out/sdk/*
            #     do
            #       i=$(basename $i)
            #       mkdir -p $out/metadata/workloads/''${i/-*}
            #       touch $out/metadata/workloads/''${i/-*}/userlocal
            #     done
            #   '';

            #   postInstall = (previousAttrs.postBuild or '''')
            #   + ''
            #     if [ ! -w "$HOME" ]; then
            #       export HOME=$(mktemp -d) # Dotnet expects a writable home directory for its configuration files
            #     fi
            #     $out/bin/dotnet workload install maui
            #   '';
          });
      in {
        devShell = pkgs.mkShell {
          nativeBuildInputs = [
            dotnet-combined
            pkgs.reveal-md
            pkgs.nodePackages.mermaid-cli
            pkgs.nodejs_21
          ];
          buildInputs = [];
        };
      }
    );
}
