{
  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-25.11";
    nixpkgs-reveal-md.url = "github:NixOS/nixpkgs/nixos-24.05";
    flake-parts.url = "github:hercules-ci/flake-parts";
    treefmt-nix.url = "github:numtide/treefmt-nix";
    haumea.url = "github:nix-community/haumea";
  };

  outputs =
    inputs:
    let
      inherit (inputs.nixpkgs) lib;
      h = inputs.haumea.lib;
    in
    inputs.flake-parts.lib.mkFlake { inherit inputs; } {
      imports = [
        inputs.treefmt-nix.flakeModule
      ];

      systems = [
        "x86_64-linux"
        "aarch64-darwin"
      ];

      ### Per-System
      perSystem =
        {
          self',
          inputs',
          pkgs,
          config,
          system,
          ...
        }:
        {
          _module.args = {
            pkgs = import inputs.nixpkgs {
              inherit system;
              config.allowUnfree = true;
            };
          };

          devShells = h.load {
            src = ./nix/devShells;
            inputs = {
              inherit
                pkgs
                self'
                inputs'
                inputs
                ;
            };
          };
          treefmt = {
            projectRootFile = "flake.nix";
            programs.nixfmt.enable = true;
          };
        };
    };

  # outputs = {
  #   self,
  #   nixpkgs,
  #   flake-utils,
  # }:
  #   flake-utils.lib.eachDefaultSystem (
  #     system: let
  #       pkgs = nixpkgs.legacyPackages.${system};
  #       pkgs-reveal-md = self.inputs.nixpkgs-reveal-md.legacyPackages.${system};
  #     in {
  #       devShell = pkgs.mkShell {
  #         nativeBuildInputs = with pkgs; [
  #           dotnetCorePackages.dotnet_8.sdk
  #           nodePackages.mermaid-cli
  #           nodejs
  #           http-server
  #           pkgs-reveal-md.reveal-md
  #         ];
  #       };
  #     }
  #   );
}
